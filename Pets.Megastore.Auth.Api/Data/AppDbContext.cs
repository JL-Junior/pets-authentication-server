using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Pets.Megastore.Auth.Api.Utils;

namespace Pets.Megastore.Auth.Api.Data
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            IConfiguration configuration,
            ILogger<AppDbContext> logger
            ): base(options)
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            IEnumerable<IMutableEntityType> entities = builder.Model.GetEntityTypes();

            ConfigureColumnNames(entities);
            ConfigureTableNames(entities);
        }

        private void ConfigureTableNames(IEnumerable<IMutableEntityType> entities)
        {
            foreach(IMutableEntityType entity in entities){
                EntityTypeBuilder entityBuilder = new EntityTypeBuilder(entity);
                DbUtils.ConfigureTableName(entityBuilder, entityBuilder.Metadata.ClrType);
            }
        }

        private void ConfigureColumnNames(IEnumerable<IMutableEntityType> entities)
        {
            
            foreach(IMutableEntityType entity in entities){
                EntityTypeBuilder entityBuilder = new EntityTypeBuilder(entity);
                DbUtils.ConfigureColumnNames(entityBuilder, entityBuilder.Metadata.ClrType);
            }
        }
    }
}