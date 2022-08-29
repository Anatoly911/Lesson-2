using System.Collections.Generic;

namespace Lesson_2.Responses.Contract
{
    public class GetAllContractsResponse
    {
        public List<ContractDto> Contracts { get; set; }
    }
}
