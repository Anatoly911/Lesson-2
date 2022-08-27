using Lesson_2.Db;
using Lesson_2.Entity;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Lesson_2.Repository
{
    internal sealed class EmployeesRepository : IEmployeesRepository
    {
        private readonly EmployeesDbContext _context;
        public EmployeesRepository(EmployeesDbContext context)
        {
            _context = context;
        }
        public bool Add(Employees entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }
        public IReadOnlyList<Employees> Get()
        {
            return _context.Employees.Where(x => x.IsDeleted == false).ToList();
        }
        public bool Update(Employees entity)
        {
            return Commit();
        }
        public bool Delete(int id)
        {
            Employees entity = _context.Employees.Find(id);
            entity.IsDeleted = true;
            return Commit();
        }
        private bool Commit()
        {
            int count = _context.SaveChanges();
            return count > 0;
        }
    }
}
