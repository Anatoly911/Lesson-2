using FluentValidation;
using Lesson_2.Request.Invoice;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Invoice
{
    public interface ICreateInvoiceValidator : IValidationService<CreateInvoiceRequest>
    {

    }

    internal sealed class CreateInvoiceValidator : FluentValidationService<CreateInvoiceRequest>, ICreateInvoiceValidator
    {
        public CreateInvoiceValidator()
        {
            RuleFor(x => x.ContractId)
                .GreaterThan(0)
                .WithErrorCode("BRL-130.1");

            RuleFor(x => x.TaskId)
                .GreaterThan(0)
                .WithErrorCode("BRL-130.2");
        }
    }
}
