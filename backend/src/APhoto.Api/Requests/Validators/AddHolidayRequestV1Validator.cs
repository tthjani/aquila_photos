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
                .LessThan(x => x.EndDate);

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThan(x => x.StartDate);

            RuleFor(x => x.Comment)
                .MaximumLength(250);
        }
    }
}
