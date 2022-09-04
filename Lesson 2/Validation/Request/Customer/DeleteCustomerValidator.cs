using FluentValidation;
using Lesson_2.Request.Customer;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Customer
{
    public interface IDeleteCustomerValidator : IValidationService<DeleteCustomerRequest>
    {

    }

    internal sealed class DeleteCustomerValidator : FluentValidationService<DeleteCustomerRequest>, IDeleteCustomerValidator
    {
        public DeleteCustomerValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-111.1");
        }
    }
}
