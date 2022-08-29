using FluentValidation;
using Lesson_2.Request.Contract;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Contract
{
    public interface IGetAllContractsValidator : IValidationService<GetAllContractsRequest>
    {

    }

    internal sealed class GetAllContractsValidator : FluentValidationService<GetAllContractsRequest>, IGetAllContractsValidator
    {
        public GetAllContractsValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithErrorCode("BRL-102.1");
        }
    }
}
