using FluentValidation;
using Lesson_2.Request.Invoice;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Invoice
{
    public interface IDeleteInvoiceValidator : IValidationService<DeleteInvoiceRequest>
    {

    }

    internal sealed class DeleteInvoiceValidator : FluentValidationService<DeleteInvoiceRequest>, IDeleteInvoiceValidator
    {
        public DeleteInvoiceValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-131.1");
        }
    }
}
