using System.Collections.Generic;

namespace MyMellow.Domain.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TaskFlowSpotForTaskDto> ParentTaskFlowSpots { get; set; }
        public ICollection<TaskFlowDto> ChildTaskFlows { get; set; }
        public ICollection<TagDto> Tags { get; set; }
        public ICollection<TaskDto> ChildTasks { get; set; }
        public ICollection<TaskDto> ParentTasks { get; set; }
        public ICollection<ScheduleDto> Schedules { get; set; }
    }
}