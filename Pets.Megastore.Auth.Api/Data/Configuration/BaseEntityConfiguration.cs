using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Megastore.Auth.Api.Data.Entities;

namespace Pets.Megastore.Auth.Api.Data.Configuration
{
    public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.Property(p => p.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow)
            .HasColumnName("dh_created_at")
            .HasColumnType("timestamp");

            builder.Property(p => p.UpdatedAt)
            .HasDefaultValue(DateTime.UtcNow)
            .HasColumnName("dh_updated")
            .HasColumnType("timestamp");
        }
        
    }
}