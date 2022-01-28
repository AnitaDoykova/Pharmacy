using Pharmacy.Models.Requests;
using FluentValidation;

namespace Pharmacy.Validators
{
    public class ClientRequestValidator : AbstractValidator<ClientRequests>
    {
        public ClientRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(12);
            RuleFor(x => x.MoneySpend).NotNull().NotEmpty();
        }
    }
}
