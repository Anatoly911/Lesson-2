using System.Collections.Generic;

namespace Lesson_2.Responses.Invoice
{
    public class GetAllInvoicesResponse
    {
        public List<InvoiceDto> Invoices { get; set; }
        public GetAllInvoicesResponse(List<InvoiceDto> invoices)
        {
            Invoices = invoices;
        }
    }
}
