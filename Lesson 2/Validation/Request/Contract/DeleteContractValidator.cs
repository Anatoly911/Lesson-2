using FluentValidation;
using Lesson_2.Request.Contract;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Contract
{
    public interface IDeleteContractValidator : IValidationService<DeleteContractRequest>
    {

    }

    internal sealed class DeleteContractValidator : FluentValidationService<DeleteContractRequest>, IDeleteContractValidator
    {
        public DeleteContractValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-101.1");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithErrorCode("BRL-101.2");
        }
    }
}
