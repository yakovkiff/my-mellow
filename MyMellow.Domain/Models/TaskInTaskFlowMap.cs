namespace MyMellow.Domain.Models
{
    public class TaskInTaskFlowMap // which tasks are in which flows
    {
        public int Id { get; set; }

        public short OrderNumber { get; set; }

        public int TaskFlowId { get; set; }
        public TaskFlow Flow { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

    }
}