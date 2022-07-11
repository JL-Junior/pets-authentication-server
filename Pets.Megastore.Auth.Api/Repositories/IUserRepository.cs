using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Megastore.Auth.Api.Data.Entities;

namespace Pets.Megastore.Auth.Api.Repositories
{
    public interface IUserRepository
    {
        List<User> getAllUsers();
    }
}