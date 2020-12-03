using CqrsSampleFirst.Application;
using CqrsSampleFirst.Domain.Common;
using CqrsSampleFirst.Domain.Test;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsSampleFirst.Persistance
{
    public class TestDbContext : DbContext, ITestDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }

        public TestDbContext(
           DbContextOptions<TestDbContext> options,
           ICurrentUserService currentUserService)
           : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Test> Tests { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _currentUserService.GetUserId();
                    entry.Entity.Created = DateTime.Now;

                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedBy = _currentUserService.GetUserId();
                    entry.Entity.LastModified = DateTime.Now;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _currentUserService.GetUserId();
                    entry.Entity.Created = DateTime.Now;

                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedBy = _currentUserService.GetUserId();
                    entry.Entity.LastModified = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
