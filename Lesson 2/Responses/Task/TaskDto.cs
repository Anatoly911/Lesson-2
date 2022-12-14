using System;
using System.Collections.Generic;

namespace Lesson_2.Responses.Task
{
    public class TaskDto
    {
        public long id { get; set; }
        public List<long> employees { get; set; }
        public DateTimeOffset start { get; set; }
        public DateTimeOffset end { get; set; }
        public decimal pricePerHour { get; set; }
        public bool isClosed { get; set; }
    }
}
