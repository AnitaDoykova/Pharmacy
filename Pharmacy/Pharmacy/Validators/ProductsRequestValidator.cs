using Pharmacy.Models.Requests;
using FluentValidation;

namespace Pharmacy.Validators
{
    public class ProductsRequestValidator : AbstractValidator<ProductsRequests>
    {
        public ProductsRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(12);
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
    }

