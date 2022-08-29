using Lesson_2.Models;
using System.Collections.Generic;

namespace Lesson_2.Responses.Customer
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ContractFactory> Contracts { get; set; }
        public CustomerDto()
        {
            Contracts = new List<ContractFactory>();
        }
    }
}
