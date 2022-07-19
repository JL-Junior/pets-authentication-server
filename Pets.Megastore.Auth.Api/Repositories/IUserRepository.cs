using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Pets.Megastore.Auth.Api.Repositories
{
    public interface IUserRepository
    {
        List<IdentityUser> getAllUsers();
    }
}