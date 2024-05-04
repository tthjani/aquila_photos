using FluentValidation;

namespace APhoto.Api.Requests.Validators
{
    public class AcceptOrderRequestV1Validator : AbstractValidator<AcceptOrderRequestV1>
    {
        public AcceptOrderRequestV1Validator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty()
                    .WithMessage("OrderId is mandatory.")
                .GreaterThan((uint)0)
                    .WithMessage("OrderId must be greater than 0.");
        }
    }
}
