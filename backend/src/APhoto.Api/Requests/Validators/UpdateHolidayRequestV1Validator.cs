using FluentValidation;

namespace APhoto.Api.Requests.Validators
{
    public class UpdateHolidayRequestV1Validator : AbstractValidator<UpdateHolidayRequestV1>
    {
        public UpdateHolidayRequestV1Validator()
        {
            RuleFor(x => x.HolidayId)
                .NotEmpty();

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
