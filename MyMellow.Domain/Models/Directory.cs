using System;
using System.Collections.Generic;

namespace MyMellow.Domain.Models
{
    public class Directory
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }
        public Directory Parent { get; set; }

        public string Title { get; set; }

        public ICollection<Directory> Children { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<TagDirectoryMap> TagMaps { get; set; }
    }
}
