using FluentValidation;

namespace APhoto.Api.Requests.Validators
{
    public class RemoveHolidayRequestV1Validator : AbstractValidator<RemoveHolidayRequestV1>
    {
        public RemoveHolidayRequestV1Validator()
        {
            RuleFor(x => x.HolidayId)
                .NotEmpty();
        }
    }
}
