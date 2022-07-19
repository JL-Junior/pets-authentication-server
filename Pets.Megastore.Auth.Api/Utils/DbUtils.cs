using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pets.Megastore.Auth.Api.Utils
{
    public static class DbUtils
    {
        public static void ConfigureColumnNames(EntityTypeBuilder builder, Type type){
            var properties = type.GetProperties();
                
            foreach(var property in properties){
                builder.Property(property.Name).HasColumnName(property.Name.ToSnakeCase());
            }
        }

        public static void ConfigureTableName(EntityTypeBuilder builder, Type type){
            builder.ToTable(type.Name.ToSnakeCase().Replace("identity_","tb_").Replace("`1", ""));
        }
    }
}