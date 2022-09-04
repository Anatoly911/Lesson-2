using FluentValidation;
using Lesson_2.Request.Employee;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Employee
{
    public interface IGetEmployeeByIdValidator : IValidationService<GetEmployeeByIdRequest>
    {

    }

    internal sealed class GetEmployeeByIdValidator : FluentValidationService<GetEmployeeByIdRequest>, IGetEmployeeByIdValidator
    {
        public GetEmployeeByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-122.1");
        }
    }
}
