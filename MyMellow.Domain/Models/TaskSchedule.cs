using System;

namespace MyMellow.Domain.Models
{
    public class TaskSchedule
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int ScheduleId { get; set; }
        public int Schedule { get; set; }
    }
}
