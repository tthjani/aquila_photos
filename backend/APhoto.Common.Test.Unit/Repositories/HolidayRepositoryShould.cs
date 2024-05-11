using APhoto.Common.Repositories;
using APhoto.Data;

namespace APhoto.Common.Test.Unit.Repositories
{
    public class HolidayRepositoryShould
    {
        private readonly Faker _faker;
        private readonly APhotosContext _dbContext;
        private readonly IHolidayRepository _holidayRepository;
        private readonly DateTime _holidayStartDate = new DateTime(2024, 5, 5);
        private readonly DateTime _holidayEndDate = new DateTime(2024, 5, 10);

        public HolidayRepositoryShould()
        {
            _faker = new Faker();

            var options = new DbContextOptionsBuilder<APhotosContext>()
                .UseInMemoryDatabase(databaseName: _faker.Random.String(15))
                .Options;
            _dbContext = new APhotosContext(options);
            _holidayRepository = new HolidayRepository(_dbContext);

            var holiday = new Holiday
            {
                HolidayId = (uint)_faker.Random.Int(1),
                StartDate = _holidayStartDate,
                EndDate = _holidayEndDate
            };
            _dbContext.Holiday.Add(holiday);
            _dbContext.SaveChanges();
        }

        [Theory]
        [InlineAutoData(0, 0, true)]
        [InlineAutoData(2, 0, true)]
        [InlineAutoData(0, -1, true)]
        [InlineAutoData(-1, -1, true)]
        [InlineAutoData(1, 1, true)]
        [InlineAutoData(-1, 1, true)]
        [InlineAutoData(1, -1, true)]
        [InlineAutoData(-3, -6, false)]
        [InlineAutoData(6, 16, false)]
        [InlineAutoData(3, -2, true)]
        [InlineAutoData(6, 1, false)]
        public void IsEntityOverlapping_ShouldReturnCorrectValue(
            int startDateOffset,
            int endDateOffset,
            bool expectedResult)
        {
            // Arrange
            var entity = new Holiday
            {
                StartDate = _holidayStartDate.AddDays(startDateOffset),
                EndDate = _holidayEndDate.AddDays(endDateOffset)
            };

            // Act
            var result = _holidayRepository.IsEntityOverlapping(entity);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void IsEntityOverlapping_ShouldThrow_WhenEntityIsNull()
        {
            // Act
            var result = () => { _holidayRepository.IsEntityOverlapping(null!); };

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }
    }
}
