using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Pets.Megastore.Auth.Api.Data.Entities;

namespace Pets.Megastore.Auth.Api.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IEntityTypeConfiguration<BaseEntity> _baseEntityConfigurer;
        private readonly ILogger _logger;
        public AppDbContext(ILogger<AppDbContext> logger, IEntityTypeConfiguration<BaseEntity> baseEntityConfigurer)
        {
            _logger = logger;
            _baseEntityConfigurer = baseEntityConfigurer;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<BaseEntity>();
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