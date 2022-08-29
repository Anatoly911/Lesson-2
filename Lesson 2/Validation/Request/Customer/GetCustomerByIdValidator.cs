using FluentValidation;
using Lesson_2.Request.Customer;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Customer
{
    public interface IGetCustomerByIdValidator : IValidationService<GetCustomerByIdRequest>
    {

    }

    internal sealed class GetCustomerByIdValidator : FluentValidationService<GetCustomerByIdRequest>, IGetCustomerByIdValidator
    {
        public GetCustomerByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-112.1");
        }
    }
}
