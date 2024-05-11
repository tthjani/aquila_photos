using APhoto.Common.Repositories;
using APhoto.Data;
using APhoto.Infrastructure.Utility;

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

        [Theory]
        [InlineAutoData(false, false)]
        [InlineAutoData(true, true)]
        public void IsDateInAnActiveHoliday_ShouldReturnCorrectValue_WhenInHolidayInterval(
            bool checkIfOrderCreationIsAllowed,
            bool expectedResult)
        {
            // Arrange
            var date = _holidayStartDate.AddDays(1);

            // Act
            var result = _holidayRepository.IsDateInAnActiveHoliday(date, checkIfOrderCreationIsAllowed);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public async Task IsDateInAnActiveHoliday_ShouldReturnTrue_WhenInHolidayIntervalAndHolidayIsOneDayLong()
        {
            // Arrange
            var day = _faker.Date.Recent().ClearTime();
            var holiday = new Holiday
            {
                HolidayId = (uint)_faker.Random.Int(1),
                StartDate = day,
                EndDate = day
            };
            await _dbContext.Set<Holiday>().AddAsync(holiday);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = _holidayRepository.IsDateInAnActiveHoliday(day);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineAutoData(false)]
        [InlineAutoData(true)]
        public void IsDateInAnActiveHoliday_ShouldReturnFalse_WhenNotInHolidayInterval(
            bool checkIfOrderCreationIsAllowed)
        {
            // Arrange
            var date = _holidayEndDate.AddDays(1);

            // Act
            var result = _holidayRepository.IsDateInAnActiveHoliday(date, checkIfOrderCreationIsAllowed);

            // Assert
            result.Should().BeFalse();
        }
    }
}
