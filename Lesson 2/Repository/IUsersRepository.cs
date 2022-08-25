using Lesson_2.Db;
using Lesson_2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lesson_2.Repository
{
    public interface IUsersRepository : IEntitiesRepository<Users>
    {
    }

}
