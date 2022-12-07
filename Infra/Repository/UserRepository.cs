using Domain.DTO_s.Request;
using Domain.DTO_s.Response;
using Domain.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Infra.JwtConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class UserRepository : IUser
    {
        private readonly SignInManager<Client> _signInManager;
        private readonly UserManager<Client> _userManager;
        private readonly JwtOptions _jwtOptions;

        public UserRepository(SignInManager<Client> signInManager, 
                              UserManager<Client> userManager,
                              IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UserRegisterResponse> AddNewUser(UserRegisterRequest request)
        {
            var userRegister = new UserRegisterResponse();
            var userCheck = await _userManager.FindByEmailAsync(request.Email);
                if (userCheck==null)
                {
                    var user = new Client
                    {
                        UserName = request.Email,
                        Email = request.Email,
                        EmailConfirmed = true,
                        Type = UserType.CommonUser
                    };
                    var result = await _userManager.CreateAsync(user, request.Senha);
                    if (result.Succeeded)
                        await _userManager.SetLockoutEnabledAsync(user, false);

                    var userRegisterResponse = new UserRegisterResponse(result.Succeeded);
                    if (!result.Succeeded && result.Errors.Count() > 0)
                        userRegisterResponse.AddErros(result.Errors.Select(r => r.Description));
                        userRegister = userRegisterResponse;
                }

            return userRegister;
        }
        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Senha, false, true);
            if (result.Succeeded)
                return await GenerateCredentials(request.Email);

            var userLoginResponse = new UserLoginResponse();
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    userLoginResponse.AddErrors("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    userLoginResponse.AddErrors("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    userLoginResponse.AddErrors("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    userLoginResponse.AddErrors("Usuário ou senha estão incorretos");
            }

            return userLoginResponse;
        }
        public async Task<UserLoginResponse> LoginWithoutPassword(string userId)
        {
            var userLoginResponse = new UserLoginResponse();
            var user = await _userManager.FindByIdAsync(userId);

            if (await _userManager.IsLockedOutAsync(user))
                userLoginResponse.AddErrors("This account is blocked.");
            else if (!await _userManager.IsEmailConfirmedAsync(user))
                userLoginResponse.AddErrors("Confirm you e-mail for login.");

            if (userLoginResponse.Success)
                return await GenerateCredentials(user.Email);

            return userLoginResponse;
        }


        // PRIVATES //
        private async Task<UserLoginResponse> GenerateCredentials(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var accessTokenClaims = await GetClaims(user, addClaimsUser: true);
            var refreshTokenClaims = await GetClaims(user, addClaimsUser: false);

            var dateExpirationAccessToken = DateTime.UtcNow.AddSeconds(_jwtOptions.AccessTokenExpiration);
            var dateExpirationRefreshToken = DateTime.UtcNow.AddSeconds(_jwtOptions.RefreshTokenExpiration);

            var accessToken = GenerateToken(accessTokenClaims, dateExpirationAccessToken);
            var refreshToken = GenerateToken(refreshTokenClaims, dateExpirationRefreshToken);

            return new UserLoginResponse
            (
                success: true,
                accessToken: accessToken,
                refreshToken: refreshToken
            );
        }
        private async Task<IList<Claim>> GetClaims(IdentityUser user, bool addClaimsUser)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            if (addClaimsUser)
            {
                var userClaims = await _userManager.GetClaimsAsync((Client)user);
                var roles = await _userManager.GetRolesAsync((Client)user);

                claims.AddRange(userClaims);

                foreach (var role in roles)
                    claims.Add(new Claim("role", role));
            }

            return claims;
        }
        private string GenerateToken(IEnumerable<Claim> claims, DateTime dateExpiration)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: dateExpiration,
                signingCredentials: _jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        
    }
}
