namespace MyMellow.Domain.Models
{
    public class TaskFlowInTaskFlowMap
    {
        public int Id { get; set; }

        public short OrderNumber { get; set; }

        public int ParentId { get; set; }
        public TaskFlow Parent { get; set; }

        public int ChildId { get; set; }
        public TaskFlow Child { get; set; }

    }
}