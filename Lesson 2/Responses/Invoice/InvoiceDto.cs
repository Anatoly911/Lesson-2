using Lesson_2.Models;
namespace Lesson_2.Responses.Invoice
{
    public class InvoiceDto
    {
        public long Id { get; set; }
        public ContractFactory Contract { get; set; }
        public decimal Cost { get; set; }
    }
}
