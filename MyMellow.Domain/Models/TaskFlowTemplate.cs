using System.Collections.Generic;

namespace MyMellow.Domain.Models
{
    public class TaskFlowTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TaskFlowTemplatePhase> Phases { get; set; }

    }
}