using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Megastore.Auth.Api.Data;
using Pets.Megastore.Auth.Api.Data.Entities;

namespace Pets.Megastore.Auth.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public List<User> getAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}