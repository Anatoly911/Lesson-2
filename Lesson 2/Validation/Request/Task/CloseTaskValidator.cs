using FluentValidation;
using Lesson_2.Request.Task;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Task
{
    public interface ICloseTaskValidator : IValidationService<CloseTaskRequest>
    {

    }

    internal sealed class CloseTaskValidator : FluentValidationService<CloseTaskRequest>, ICloseTaskValidator
    {
        public CloseTaskValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-145.1");
        }
    }
}
