using FluentValidation;
using Lesson_2.Request.Task;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Task
{
    public interface IAddEmployeeToTaskValidator : IValidationService<AddEmployeeToTaskRequest>
    {

    }

    internal sealed class AddEmployeeToTaskValidator : FluentValidationService<AddEmployeeToTaskRequest>, IAddEmployeeToTaskValidator
    {
        public AddEmployeeToTaskValidator()
        {
            RuleFor(x => x.TaskId)
                .GreaterThan(0)
                .WithErrorCode("BRL-143.1");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0)
                .WithErrorCode("BRL-143.2");
        }
    }
}
