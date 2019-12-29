namespace MyMellow.Domain.Dtos
{
    public class TaskFlowSpotDto
    {
        public int Id { get; set; }
        public short OrderNumber { get; set; }
        public TaskFlowDto TaskFlow { get; set;}
    }
}