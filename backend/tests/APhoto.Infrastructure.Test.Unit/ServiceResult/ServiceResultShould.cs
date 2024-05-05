using APhoto.Infrastructure.Test.Unit.Utility;
using FluentAssertions;
using ServiceResultNs = APhoto.Infrastructure.ServiceResult;

namespace APhoto.Infrastructure.Test.Unit.ServiceResult
{
    public class ServiceResultShould
    {
        [Theory, AutoData]
        public void Fail_ShouldReturnFailureObject(
            string reason)
        {
            // Act
            var result = ServiceResultNs.ServiceResult.Fail(reason);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.IsSuccess.Should().BeFalse();
            result.Reason.Should().Be(reason);
        }

        [Fact]
        public void Success_ShouldReturnSuccessObject()
        {
            // Act
            var result = ServiceResultNs.ServiceResult.Success();

            // Assert
            result.IsFailure.Should().BeFalse();
            result.IsSuccess.Should().BeTrue();
            result.Reason.Should().BeNull();
        }

        [Theory, AutoData]
        public void Success_ShouldReturnSuccessObjectWithData(
            FakeEntity entity)
        {
            // Act
            var result = ServiceResultNs.ServiceResult<FakeEntity>.Success(entity);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.IsFailure.Should().BeFalse();
            result.Reason.Should().BeNull();
            result.Value.Should().NotBeNull().And.Be(entity);
        }
    }
}
