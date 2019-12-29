using System;
using System.Collections.Generic;

namespace MyMellow.Domain.Models
{
    public class TaskFlow
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TaskFlowInTaskFlowMap> ParentMaps { get; set;}
        public ICollection<TaskFlowInTaskFlowMap> ChildMaps { get; set; }
        public ICollection<TaskInTaskFlowMap> TaskInTaskFlowMaps { get; set; }
        public ICollection<TaskFlowForTaskMap> TaskFlowForTaskMaps { get; set; }
    }
}
