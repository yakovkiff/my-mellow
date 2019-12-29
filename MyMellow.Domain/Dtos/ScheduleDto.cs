using System;

namespace MyMellow.Domain.Dtos
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public TimeSpan? RepeatEvery { get; set; }
        public bool AlertByEmail { get; set; }

    }
}