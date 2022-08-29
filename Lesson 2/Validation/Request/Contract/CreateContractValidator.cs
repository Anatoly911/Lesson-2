using FluentValidation;
using Lesson_2.Request.Contract;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Contract
{
    public interface ICreateContractValidator : IValidationService<CreateContractRequest>
    {

    }

    internal sealed class CreateContractValidator : FluentValidationService<CreateContractRequest>, ICreateContractValidator
    {
        public CreateContractValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithErrorCode("BRL-100.1");

            RuleFor(x => x.Name)
                .Length(3, 20)
                .WithErrorCode("BRL-100.2");
        }
    }
}
