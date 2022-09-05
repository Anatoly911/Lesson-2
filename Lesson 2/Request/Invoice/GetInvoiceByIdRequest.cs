using System.Security.Policy;

namespace Lesson_2.Request.Invoice
{
    public class GetInvoiceByIdRequest
    {
        public long Id { get; set; }
        public GetInvoiceByIdRequest(long Id)
        {
            this.Id = Id;
        }
    }
}
