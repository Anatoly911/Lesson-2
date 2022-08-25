using System.Collections.Generic;
using Lesson_2.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lesson_2.Repository
{
    public interface IEntitiesRepository<T>
    {
        bool Add(T entity);
        IReadOnlyList<T> Get();
        bool Update(T entity);
        bool Delete(int id);
    }
}
