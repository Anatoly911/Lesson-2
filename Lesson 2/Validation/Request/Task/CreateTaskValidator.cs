using FluentValidation;
using Lesson_2.Request.Task;
using Lesson_2.Validation.Services;


namespace Lesson_2.Validation.Request.Task
{
    public interface ICreateTaskValidator : IValidationService<CreateTaskRequest>
    {

    }

    internal sealed class CreateTaskValidator : FluentValidationService<CreateTaskRequest>, ICreateTaskValidator
    {
        public CreateTaskValidator()
        {
            RuleFor(x => x.PricePerHour)
                .GreaterThan(0)
                .WithErrorCode("BRL-140.1");
        }
    }
}
