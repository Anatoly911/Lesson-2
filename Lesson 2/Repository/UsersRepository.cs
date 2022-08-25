using Lesson_2.Db;
using System.Collections.Generic;
using System;
using Lesson_2.Entity;
using System.Linq;

namespace Lesson_2.Repository
{
    internal sealed class UsersRepository : IUsersRepository
    {
        private readonly UsersDbContext _context;
        public UsersRepository(UsersDbContext context)
        {
            _context = context;
        }
        public bool Add(Users entity)
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
        public IReadOnlyList<Users> Get()
        {
           return _context.Users.Where(x => x.IsDeleted == false).ToList();
        }
        public bool Update(Users entity)
        {
            return Commit();
        }
        public bool Delete(int id)
        {
            Users entity = _context.Users.Find(id);
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
