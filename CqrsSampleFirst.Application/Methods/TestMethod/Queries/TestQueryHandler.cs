using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsSampleFirst.Application.Methods.TestMethod.Queries
{
    public class TestQueryHandler : IRequestHandler<TestQuery, TestVM>
    {
        private readonly ITestDbContext _context;
        public TestQueryHandler(ITestDbContext context)
        {
            _context = context;
        }
        public async Task<TestVM> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            var testDatas = await _context.Tests.Where(x => x.Active).SingleOrDefaultAsync();
            return new TestVM { Result = new TestDto { Value = testDatas.Value } };
        }
    }
}
