using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Megastore.Auth.Api.Data.Entities;

namespace Pets.Megastore.Auth.Api.Data.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_users");

            builder.HasKey(p => p.Id)
                .HasName("pk_users");

            builder.Property( p => p.Id)
            .HasIdentityOptions(0,1,1,null,false,null)
            .HasColumnName("id_user")
            .HasColumnType("int8")
            .IsRequired();

            builder.Property(p => p.FirstName)
                .HasColumnName("tx_first_name")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder.Property(p => p.FirstName)
                .HasColumnName("tx_last_name")
                .HasColumnType("varchar")
                .HasMaxLength(50);
            
            builder.Property( p => p.UserName)
                .HasColumnName("tx_user_name")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder.Property( p => p.Password)
                .HasColumnName("tx_password")
                .HasColumnType("varchar")
                .HasMaxLength(64);

        }
    }
}