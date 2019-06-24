using System;

namespace MyMellow.Domain.Models
{
    public class NoteSchedule
    {
        public int Id { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }

        public int ScheduleId { get; set; }
        public int Schedule { get; set; }
    }
}
