using FluentValidation;

namespace APhoto.Api.Requests.Validators
{
    public class AddOrderRequestV1Validator : AbstractValidator<AddOrderRequestV1>
    {
        public AddOrderRequestV1Validator()
        {
            RuleFor(x => x.ClientName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.ContactInformation)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Message)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.FbUrl)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.OrderType)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
