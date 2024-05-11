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
                .LessThanOrEqualTo(x => x.EndDate);

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(x => x.StartDate);

            RuleFor(x => x.Comment)
                .MaximumLength(250);
        }
    }
}
