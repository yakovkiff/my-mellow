using System;
using System.Collections.Generic;

namespace MyMellow.Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public TimeSpan? RepeatEvery { get; set; }
        public bool AlertByEmail { get; set; }

        public ICollection<NoteSchedule> Notes { get; set; }
        public ICollection<TaskSchedule> Tasks { get; set; }
    }
}
