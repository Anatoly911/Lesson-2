using FluentValidation;
using Lesson_2.Request.Invoice;
using Lesson_2.Validation.Services;

namespace Lesson_2.Validation.Request.Invoice
{
    public interface IGetInvoiceByIdValidator : IValidationService<GetInvoiceByIdRequest>
    {

    }

    internal sealed class GetInvoiceByIdValidator : FluentValidationService<GetInvoiceByIdRequest>, IGetInvoiceByIdValidator
    {
        public GetInvoiceByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithErrorCode("BRL-122.1");
        }
    }
}
