using FluentValidation;

namespace APhoto.Api.Requests.Validators
{
    public class AddHolidayRequestV1Validator : AbstractValidator<AddHolidayRequestV1>
    {
        public AddHolidayRequestV1Validator()
        {
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Today)
                .LessThanOrEqualTo(x => x.EndDate);

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(x => x.StartDate);

            RuleFor(x => x.Comment)
                .MaximumLength(250);
        }
    }
}
