using AutoMapper;
using Lesson_2.Models;
using Lesson_2.Responses.Contract;
using Lesson_2.Responses.Customer;
using Lesson_2.Responses.Employee;
using Lesson_2.Responses.Invoice;
using Lesson_2.Responses.Task;
using Contract = Lesson_2.Models.Contract;
using Task = Lesson_2.Models.Task;

namespace Lesson_2
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Task, TaskDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Contract, ContractDto>();
            CreateMap<Invoice, InvoiceDto>();
        }
    }
}