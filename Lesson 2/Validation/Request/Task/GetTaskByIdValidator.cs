using FluentValidation;
using Lesson_2.Request.Task;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Task
{
    public interface IGetTaskByIdValidator : IValidationService<GetTaskByIdRequest>
    {

    }

    internal sealed class GetTaskByIdValidator : FluentValidationService<GetTaskByIdRequest>, IGetTaskByIdValidator
    {
        public GetTaskByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-142.1");
        }
    }
}
