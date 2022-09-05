using Lesson_2.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Lesson_2.Responses.Invoice
{
    public class InvoiceDto
    {
        public long Id { get; set; }
        public ContractFactory Contract { get; set; }
        public decimal Cost { get; set; }

        public InvoiceDto(long Id)
        {
            this.Id = Id;
            this.Contract = new ContractFactory();
            this.Cost = 0;
        }
    }
    
}
