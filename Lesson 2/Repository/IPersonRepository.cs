﻿using Lesson_2.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lesson_2.Repository
{
    public interface IPersonRepository : IEntitiesRepository<Person>
    {
        
    }
}
