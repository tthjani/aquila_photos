using Microsoft.EntityFrameworkCore;

namespace APhoto.Infrastructure.Test.Unit.Utility
{
    public  class FakeDbContext : DbContext
    {
        public FakeDbContext(DbContextOptions<FakeDbContext> options) : base(options)
        {
        }

        public DbSet<FakeEntity> TestTable { get; set; }
    }
}
