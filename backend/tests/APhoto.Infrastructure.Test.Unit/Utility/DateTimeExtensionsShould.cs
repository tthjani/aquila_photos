using APhoto.Infrastructure.Utility;

namespace APhoto.Infrastructure.Test.Unit.Utility
{
    public class DateTimeExtensionsShould
    {
        private readonly Faker _faker;

        public DateTimeExtensionsShould()
        {
            _faker = new Faker();
        }

        [Fact]
        public void ClearTime_ShouldReturnExpectedObject()
        {
            // Arrange
            var date = _faker.Date.Recent();

            // Act
            var result = date.ClearTime();

            // Assert
            result.Year.Should().Be(date.Year);
            result.Month.Should().Be(date.Month);
            result.Day.Should().Be(date.Day);
            result.Hour.Should().Be(0);
            result.Minute.Should().Be(0);
            result.Second.Should().Be(0);
            result.Millisecond.Should().Be(0);
            result.Microsecond.Should().Be(0);
        }
    }
}
