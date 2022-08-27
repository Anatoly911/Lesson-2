﻿using Microsoft.Extensions.DependencyInjection;

namespace Lesson_2.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public object Comment { get; internal set; }
        public bool IsDeleted { get; internal set; }
    }
}