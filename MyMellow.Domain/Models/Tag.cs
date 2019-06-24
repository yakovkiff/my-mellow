using System;
using System.Collections.Generic;

namespace MyMellow.Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TagTaskMap> TaskMaps { get; set; }
        public ICollection<TagNoteMap> NoteMaps { get; set; }
        public ICollection<TagDirectoryMap> DirectoryMaps { get; set; }

    }
}
