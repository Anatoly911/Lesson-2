using FluentValidation;
using Lesson_2.Request.Employee;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Employee
{
    public interface ICreateEmployeeValidator : IValidationService<CreateEmployeeRequest>
    {

    }

    internal sealed class CreateEmployeeValidator : FluentValidationService<CreateEmployeeRequest>, ICreateEmployeeValidator
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Name)
                .Length(3, 20)
                .WithErrorCode("BRL-120.1");
        }
    }
}
