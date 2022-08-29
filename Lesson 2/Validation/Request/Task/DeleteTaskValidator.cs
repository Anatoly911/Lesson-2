using FluentValidation;
using Lesson_2.Request.Task;
using Lesson_2.Validation.Services;


namespace Lesson_2.Validation.Request.Task
{
    public interface IDeleteTaskValidator : IValidationService<DeleteTaskRequest>
    {

    }

    internal sealed class DeleteTaskValidator : FluentValidationService<DeleteTaskRequest>, IDeleteTaskValidator
    {
        public DeleteTaskValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-141.1");
        }
    }
}
