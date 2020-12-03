using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace CqrsSampleFirst.Persistance
{
    public class ITicketDbContextFactory : DesignTimeDbContextFactoryBase<TestDbContext>
    {
        public ITicketDbContextFactory() { }
        protected override TestDbContext CreateNewInstance(DbContextOptions<TestDbContext> options)
        {
            return new TestDbContext(options);
        }


    }
}
