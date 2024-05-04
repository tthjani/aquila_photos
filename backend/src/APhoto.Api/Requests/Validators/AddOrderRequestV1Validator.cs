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

            RuleFor(x => x.ClientEmail)
                .NotEmpty()
                .MaximumLength(50)
                .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");

            RuleFor(x => x.Message)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.FbUrl)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Type)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
