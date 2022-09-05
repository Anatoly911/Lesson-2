namespace Lesson_2.Request.Invoice
{
    public class DeleteInvoiceRequest
    {
        public long Id { get; set; }
        public DeleteInvoiceRequest(long id)
        {
            Id = id;
        }
    }
}
