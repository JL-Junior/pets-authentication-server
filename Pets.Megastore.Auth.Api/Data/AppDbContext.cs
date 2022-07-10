using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Pets.Megastore.Auth.Api.Data.Entities;
using Pets.Megastore.Auth.Api.Utils;

namespace Pets.Megastore.Auth.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> users {get;set;}
        private readonly IEntityTypeConfiguration<BaseEntity> _baseEntityConfigurer;
        private readonly IEntityTypeConfiguration<User> _userConfigurer;

        private readonly IConfiguration _configuration;

        private readonly ILogger _logger;
        public AppDbContext(
            ILogger<AppDbContext> logger, 
            IConfiguration configuration,
            IEntityTypeConfiguration<BaseEntity> baseEntityConfigurer,
            IEntityTypeConfiguration<User> userConfigurer)
        {
            _configuration = configuration;
            _logger = logger;
            _baseEntityConfigurer = baseEntityConfigurer;
            _userConfigurer = userConfigurer;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();            
            sb.Database = _configuration["AUTH_API_DB_DATABASE"];
            sb.Host = _configuration["AUTH_API_DB_HOST"];
            sb.Port = int.Parse(_configuration["AUTH_API_DB_PORT"]?? DefaultUtils.API_DB_PORT);
            sb.Password = _configuration["AUTH_API_DB_PASSWORD"];
            sb.Username = _configuration["AUTH_API_DB_USER"];
           
            optionsBuilder.UseNpgsql(sb.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<BaseEntity>(_baseEntityConfigurer);            
            modelBuilder.ApplyConfiguration<User>(_userConfigurer);            
        }
        
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var baseEntries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity);
            var utcNow = DateTime.UtcNow;
            baseEntries.ToList().ForEach(this.SetProperties);
        }

        private void SetProperties(EntityEntry entry)
        {
            BaseEntity trackable = (BaseEntity) entry.Entity;
            var utcNow = DateTime.UtcNow;
            switch (entry.State)
            {
                case EntityState.Modified:
                    trackable.UpdatedAt = utcNow;
                    entry.Property("CreatedAt").IsModified = false;
                    break;

                case EntityState.Added:
                    trackable.CreatedAt = utcNow;
                    trackable.UpdatedAt = utcNow;
                    break;
            }
        }
    }
}