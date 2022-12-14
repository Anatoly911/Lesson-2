using Lesson_2.Request.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Lesson_2.Models;

namespace Lesson_2.Repository
{
    public interface IEmployeeRepository
    {
        Task Create(CreateEmployeeRequest request);
        Task Delete(DeleteEmployeeRequest request);
        Task<List<Model.Employee>> GetAll();
        Task<Model.Employee> GetById(GetEmployeeByIdRequest request);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        TimesheetsDbContext _context;

        public EmployeeRepository(TimesheetsDbContext context)
        {
            _context = context;
        }

        public async Task Create(CreateEmployeeRequest request)
        {
            try
            {
                var lastItem = await _context
                    .Employees
                    .OrderBy(x => x.id)
                    .LastOrDefaultAsync();
                var id = lastItem != null ? lastItem.id + 1 : 1;
                var factory = new Model.EmployeeFactory();
                var item = factory.Create(id, request.Name);

                await _context.Employees.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }

        public async Task Delete(DeleteEmployeeRequest request)
        {
            try
            {
                var item = await _context
                    .Employees
                    .Where(x => x.id == request.Id)
                    .SingleOrDefaultAsync();

                _context.Employees.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<Model.Employee>> GetAll()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception)
            {

            }

            return null;
        }

        public async Task<Model.Employee> GetById(GetEmployeeByIdRequest request)
        {
            try
            {
                return await _context
                    .Employees
                    .Where(x => x.id == request.Id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
