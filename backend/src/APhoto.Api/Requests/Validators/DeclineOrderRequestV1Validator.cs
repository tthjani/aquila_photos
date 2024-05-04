using FluentValidation;

namespace APhoto.Api.Requests.Validators
{
    public class DeclineOrderRequestV1Validator : AbstractValidator<DeclineOrderRequestV1>
    {
        public DeclineOrderRequestV1Validator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty();

            RuleFor(x => x.Reason)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
