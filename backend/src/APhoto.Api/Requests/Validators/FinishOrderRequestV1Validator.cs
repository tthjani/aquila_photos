using FluentValidation;

namespace APhoto.Api.Requests.Validators
{
    public class FinishOrderRequestV1Validator : AbstractValidator<FinishOrderRequestV1>
    {
        public FinishOrderRequestV1Validator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty();
        }
    }
}
