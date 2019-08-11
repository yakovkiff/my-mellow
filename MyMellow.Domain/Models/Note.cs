using System;
using System.Collections.Generic;

namespace MyMellow.Domain.Models
{
    public class Note
    {
        public int Id { get; set; }

        public int DirectoryId { get; set; }
        public Directory Directory { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public ICollection<TagNoteMap> TagMaps { get; set; }
        public ICollection<NoteSchedule> Schedules { get; set; }
    }
}
