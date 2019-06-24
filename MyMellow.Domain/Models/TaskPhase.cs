using System;

namespace MyMellow.Domain.Models
{
    public class TaskPhase
    {
        public int Id { get; set; }

        public int TaskFlowId { get; set; }
        public TaskFlow TaskFLow { get; set; }

        public string Name { get; set; }
        public short OrderNumber { get; set; }
    }
}
