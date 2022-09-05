namespace Lesson_2.Responses.Invoice
{
    public class GetInvoiceByIdResponse
    {
        public InvoiceDto Invoice { get; set; }
        public GetInvoiceByIdResponse(InvoiceDto Invoice)
        {
            this.Invoice = Invoice;
        }
    }
}
