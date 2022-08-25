﻿using Lesson_2.Db;
using Lesson_2.Entity;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Lesson_2.Repository
{
    internal sealed class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _context;
        public PersonRepository(PersonDbContext context)
        {
            _context = context;
        }
        public bool Add(Person entity)
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
        public IReadOnlyList<Person> Get()
        {
            return _context.Person.Where(x => x.IsDeleted == false).ToList();
        }
        public bool Update(Person entity)
        {
            return Commit();
        }
        public bool Delete(int id)
        {
            Person entity = _context.Person.Find(id);
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
