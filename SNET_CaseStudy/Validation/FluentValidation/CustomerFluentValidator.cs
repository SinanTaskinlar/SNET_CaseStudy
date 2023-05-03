using SNET_CaseStudy.Validation.FluentValidation;
using SNET_CaseStudy.Entities;
using FluentValidation;

namespace SNET_CaseStudy.Validation.FluentValidation
{
    public class CustomerFluentValidator : AbstractValidator<Customer>
    {
        public CustomerFluentValidator()
        {
            //RuleFor(p => p.ProductName).NotEmpty();
            //RuleFor(p => p.ProductName).MinimumLength(2);
            //RuleFor(p => p.UnitPrice).NotEmpty();
            //RuleFor(p => p.UnitPrice).GreaterThan(0);
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10)
            //    .When(p => p.CategoryId == 1);
            //RuleFor(p => p.ProductName).Must(StartWithA)
            //    .WithMessage("Ürünler A harfi ile başlamalı");
        }
    }
}
