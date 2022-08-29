using FluentValidation;
using Lesson_2.Request.Task;
using Lesson_2.Validation.Services;


namespace Lesson_2.Validation.Request.Task
{
    public interface IRemoveEmployeeFromTaskValidator : IValidationService<RemoveEmployeeFromTaskRequest>
    {

    }

    internal sealed class RemoveEmployeeFromTaskValidator : FluentValidationService<RemoveEmployeeFromTaskRequest>, IRemoveEmployeeFromTaskValidator
    {
        public RemoveEmployeeFromTaskValidator()
        {
            RuleFor(x => x.TaskId)
                .GreaterThan(0)
                .WithErrorCode("BRL-144.1");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0)
                .WithErrorCode("BRL-144.2");
        }
    }
}
