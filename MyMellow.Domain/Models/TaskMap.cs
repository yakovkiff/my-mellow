using System;

namespace MyMellow.Domain.Models
{
    public class TaskMap
    {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public Task Parent { get; set; }

        public int ChildId { get; set; }
        public Task Child { get; set; }
    }
}
