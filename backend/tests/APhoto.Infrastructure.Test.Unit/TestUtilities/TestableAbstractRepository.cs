namespace APhoto.Infrastructure.Test.Unit.TestUtilities
{
    public class TestableAbstractRepository : AbstractRepository<FakeEntity>
    {
        public TestableAbstractRepository(FakeDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
