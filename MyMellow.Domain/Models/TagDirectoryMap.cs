using System;

namespace MyMellow.Domain.Models
{
    public class TagDirectoryMap
    {
        public int Id { get; set; }

        public int DirectoryId { get; set; }
        public Directory Directory { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
