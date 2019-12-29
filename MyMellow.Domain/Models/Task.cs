using System;
using System.Collections.Generic;

namespace MyMellow.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        // public DateTime CreatedAt { get; set; }
        // public DateTime? CompletedAt { get; set; }

        public ICollection<TaskInTaskFlowMap> ParentTaskFlowMaps { get; set; }
        public ICollection<TaskFlowForTaskMap> ChildTaskFlowMaps { get; set; }
        public ICollection<TagTaskMap> TagMaps { get; set; }
        public ICollection<TaskMap> ChildTaskMaps { get; set; }
        public ICollection<TaskMap> ParentTaskMaps { get; set; }
        public ICollection<TaskSchedule> Schedules { get; set; }
    }
}
