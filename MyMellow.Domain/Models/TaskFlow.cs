using System;
using System.Collections.Generic;

namespace MyMellow.Domain.Models
{
    public class TaskFlow
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TaskPhase> Phases { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
