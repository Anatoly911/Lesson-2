using FluentValidation;
using Lesson_2.Request.Contract;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Contract
{
    public interface IGetContractByIdValidator : IValidationService<GetContractByIdRequest>
    {

    }

    internal sealed class GetContractByIdValidator : FluentValidationService<GetContractByIdRequest>, IGetContractByIdValidator
    {
        public GetContractByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-103.1");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithErrorCode("BRL-103.2");
        }
    }
}
