using Domain.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryClient : IClient
    {

        private readonly DbContextOptions<Context> _optionsbuilder;

        public RepositoryClient()
        {
            _optionsbuilder = new DbContextOptions<Context>();
        }

        public async Task<List<Client>> ListClients()
        {
            using (var data = new Context(_optionsbuilder))
            {
                return await data.Client.ToListAsync();
            }
        }
        public async Task<Client> GetUser(string id)
        {
            using (var data = new Context(_optionsbuilder))
            {
                var user = await data.Client.FindAsync(id);
                if (user != null || user.Id == id)
                {
                    return user;
                }
            }
            return null;


        }
        public async Task<bool> AddUser(string name, string email, string phone, string address, string password)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    var check = await data.Client.FindAsync(email);
                    if (check == null)
                    {
                        await data.Client.AddAsync(
                          new Client
                          {
                              UserName = name,
                              Email = email,
                              PhoneNumber = phone,
                              Address = address,
                              PasswordHash = password,
                              Type = UserType.CommonUser,
                              Status = 1
                          });
                        await data.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public async Task<bool> UpdateUser(string name, string email, string phone, string address, string password)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    var check = await data.Client.FindAsync(email);
                    if (check == null)
                    {
                        await data.Client.AddAsync(
                          new Client
                          {
                              UserName = name,
                              Email = email,
                              PhoneNumber = phone,
                              Address = address,
                              PasswordHash = password,
                              Type = UserType.CommonUser,
                              Status = 1
                          });
                        await data.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public async Task<bool> CheckUser(string email, string password)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    return await data.Client.
                           Where(x => x.Email.Equals(email) &&
                           x.PasswordHash.Equals(password))
                           .AsNoTracking()
                           .AnyAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteUser(string id)
        {
            bool check = false;
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    var user = await data.Client.FindAsync(id);
                    if (user != null || user.Id == id)
                    {
                        data.Client.Remove(user);
                        await data.SaveChangesAsync();
                        var userCheck = await data.Client.FindAsync(id);
                        if (userCheck == null)
                            check = true;
                    }
                }
            }
            catch (Exception)
            {
                return check;
            }

            return check;
        }
        public async Task<string> ReturnIdUser(string id)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    var client = await data.Client.
                           Where(x => x.Id == id)
                           .AsNoTracking()
                           .FirstOrDefaultAsync();

                    return client.Id;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}
