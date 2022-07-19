using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pets.Megastore.Auth.Api.Data;

namespace Pets.Megastore.Auth.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public List<IdentityUser> getAllUsers()
        {
            return _context.Users.AsNoTracking().ToList();
        }
    }
}