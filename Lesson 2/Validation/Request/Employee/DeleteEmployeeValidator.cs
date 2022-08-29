using FluentValidation;
using Lesson_2.Request.Employee;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Employee
{
    public interface IDeleteEmployeeValidator : IValidationService<DeleteEmployeeRequest>
    {

    }

    internal sealed class DeleteEmployeeValidator : FluentValidationService<DeleteEmployeeRequest>, IDeleteEmployeeValidator
    {
        public DeleteEmployeeValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-121.1");
        }
    }
}
