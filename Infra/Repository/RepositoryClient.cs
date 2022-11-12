﻿using Domain.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Infra.Configuration;
using Infra.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryClient : RepositoryGeneric<Client>, IClient
    {

        private readonly DbContextOptions<Context> _optionsbuilder;

        public RepositoryClient()
        {
            _optionsbuilder = new DbContextOptions<Context>();
        }

        public async Task<bool> AddUser(string name, string email, string address, string password, string phone)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    await data.Client.AddAsync(
                          new Client
                          {
                              Name = name,
                              Email = email,
                              Address = address,
                              Password = password,
                              Phone = phone,
                              Type = UserType.CommonUser
                          });

                    await data.SaveChangesAsync();

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
                           x.Password.Equals(password))
                           .AsNoTracking()
                           .AnyAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> ReturnIdUser(string email)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    var client = await data.Client.
                           Where(x => x.Email.Equals(email))
                           .AsNoTracking()
                           .FirstOrDefaultAsync();

                    return client.Email;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}