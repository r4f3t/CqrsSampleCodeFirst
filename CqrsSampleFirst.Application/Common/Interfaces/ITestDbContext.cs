using CqrsSampleFirst.Domain.Test;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsSampleFirst.Application
{
    public interface ITestDbContext
    {
        public DbSet<Test> Tests { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
