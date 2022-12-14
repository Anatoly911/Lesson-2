using Lesson_2.Request.Task;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Lesson_2.Models;

namespace Lesson_2.Repositories
{
    public interface ITaskRepository
    {
        Task Create(CreateTaskRequest request);
        Task Delete(DeleteTaskRequest request);
        Task<List<Model.Task>> GetAll();
        Task<Model.Task> GetById(GetTaskByIdRequest request);
        Task AddEmployeeToTask(AddEmployeeToTaskRequest request);
        Task RemoveEmployeeFromTask(RemoveEmployeeFromTaskRequest request);
        Task CloseTask(CloseTaskRequest request);
    }
    public class TaskRepository : ITaskRepository
    {
        TimesheetsDbContext _context;

        public TaskRepository(TimesheetsDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployeeToTask(AddEmployeeToTaskRequest request)
        {
            try
            {
                var item = await _context
                    .Tasks
                    .Where(x => x.id == request.TaskId)
                    .SingleOrDefaultAsync();

                item.AddEmployee(request.EmployeeId);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }

        public async Task CloseTask(CloseTaskRequest request)
        {
            try
            {
                var item = await _context
                    .Tasks
                    .Where(x => x.id == request.Id)
                    .SingleOrDefaultAsync();

                item.Close(new Model.SystemTime());
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }

        public async Task Create(CreateTaskRequest request)
        {
            try
            {
                var lastItem = await _context
                    .Tasks
                    .OrderBy(x => x.id)
                    .LastOrDefaultAsync();
                var id = lastItem != null ? lastItem.id + 1 : 1;
                var factory = new Model.TaskFactory();
                var item = factory.Create(id, request.PricePerHour, new Model.SystemTime());

                await _context.Tasks.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }

        public async Task Delete(DeleteTaskRequest request)
        {
            try
            {
                var item = await _context
                    .Tasks
                    .Where(x => x.id == request.Id)
                    .SingleOrDefaultAsync();

                _context.Tasks.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<Model.Task>> GetAll()
        {
            try
            {
                return await _context.Tasks.ToListAsync();
            }
            catch (Exception)
            {

            }

            return null;
        }

        public async Task<Model.Task> GetById(GetTaskByIdRequest request)
        {
            try
            {
                return await _context
                    .Tasks
                    .Where(x => x.id == request.Id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception)
            {

            }

            return null;
        }

        public async Task RemoveEmployeeFromTask(RemoveEmployeeFromTaskRequest request)
        {
            try
            {
                var item = await _context
                    .Tasks
                    .Where(x => x.id == request.TaskId)
                    .SingleOrDefaultAsync();

                item.RemoveEmployee(request.EmployeeId);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }
    }
}
