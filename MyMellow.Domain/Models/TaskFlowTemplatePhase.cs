namespace MyMellow.Domain.Models
{
    public class TaskFlowTemplatePhase
    {
        public int Id { get; set; }

        public int TaskFlowTemplateId { get; set; }
        public TaskFlowTemplate Template { get; set; }

        public string Name { get; set; }
        public short OrderNumber { get; set; }

    }
}