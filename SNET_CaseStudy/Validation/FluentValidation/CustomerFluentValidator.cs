using FluentValidation;
using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.Validation.FluentValidation
{
    public class CustomerFluentValidator : AbstractValidator<Customer>
    {
        public CustomerFluentValidator()
        {

        }
    }
}
