namespace APhoto.Infrastructure.Test.Unit.Utility
{
    public class TestableAbstractRepository : AbstractRepository<FakeEntity>
    {
        public TestableAbstractRepository(FakeDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
