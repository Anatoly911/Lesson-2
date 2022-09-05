namespace Lesson_2.Request.Invoice
{
    public class CreateInvoiceRequest
    {
        public long ContractId { get; set; }

        public long TaskId { get; set; }

        public CreateInvoiceRequest(long ContractId)
        {
            this.ContractId = ContractId;
            this.TaskId = TaskId;
        }
    }
}
    