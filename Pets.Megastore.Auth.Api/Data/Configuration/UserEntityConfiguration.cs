using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pets.Megastore.Auth.Api.Utils;

namespace Pets.Megastore.Auth.Api.Data.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUser> builder)
        {
            
            builder.HasIndex(p => p.NormalizedEmail, "idx_normalized_email");
            builder.HasIndex(p => p.UserName, "idx_user_name");
        }
    }
}