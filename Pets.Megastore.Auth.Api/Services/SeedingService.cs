using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Pets.Megastore.Auth.Api.Services
{
    public static class SeedingService
    {

        public static async Task<ICollection<IdentityRole>> GetIdentityRoles(){

            return new IdentityRole[]{
                await GenerateIdentityRole("User", "USER"),
                await GenerateIdentityRole("Admin", "ADMIN"),
                await GenerateIdentityRole("Read Products", "READ_PRODUCTS"),
                await GenerateIdentityRole("Edit Products", "EDIT_PRODUCTS")
            };
        }

        private static async Task<IdentityRole> GenerateIdentityRole(string name, string normalizedName)
        {
            var role = new IdentityRole(name);
            role.NormalizedName = normalizedName;
            return role;
        }
    }
}