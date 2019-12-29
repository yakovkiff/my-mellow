namespace MyMellow.Domain.Models
{
    public class TaskFlowForTaskMap // which Flows belong to which Tasks
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int TaskFlowId { get; set; }
        public TaskFlow Flow { get; set; }
    }
}