using Pharmacy.Models.Requests;
using FluentValidation;

namespace Pharmacy.Validators
{
    public class ShiftRequestValidator : AbstractValidator<ShiftRequests>
    {
        public ShiftRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(12);
            RuleFor(x => x.Employees).NotNull().NotEmpty();
        }
    }
    }

