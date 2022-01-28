using Pharmacy.Models.Requests;
using FluentValidation;

namespace Pharmacy.Validators
{
    public class EmployeeRequestValidator : AbstractValidator<EmployeeRequests>
    {
        public EmployeeRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(12);
            RuleFor(x => x.Salary).NotNull().NotEmpty().GreaterThanOrEqualTo(450);
        }
    }
    }

