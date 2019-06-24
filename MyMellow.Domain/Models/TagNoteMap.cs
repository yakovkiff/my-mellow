using System;

namespace MyMellow.Domain.Models
{
    public class TagNoteMap
    {
        public int Id { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
