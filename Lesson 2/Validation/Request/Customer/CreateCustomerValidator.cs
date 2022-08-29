using FluentValidation;
using Lesson_2.Request.Customer;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Customer
{
    public interface ICreateCustomerValidator : IValidationService<CreateCustomerRequest>
    {

    }

    internal sealed class CreateCustomerValidator : FluentValidationService<CreateCustomerRequest>, ICreateCustomerValidator
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name)
                .Length(3, 20)
                .WithErrorCode("BRL-110.1");
        }
    }
}
