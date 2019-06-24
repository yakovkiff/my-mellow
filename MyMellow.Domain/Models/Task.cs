using System;
using System.Collections.Generic;

namespace MyMellow.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }

        public int TaskFlowId { get; set; }
        public TaskFlow Flow { get; set; }

        public string Name { get; set; }
        public short OrderNumber { get; set; }
        
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public ICollection<TagTaskMap> TagMaps { get; set; }
        public ICollection<TaskMap> ChildMaps { get; set; }
        public ICollection<TaskMap> ParentMaps { get; set; }
    }
}
