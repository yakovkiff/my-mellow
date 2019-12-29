using System.Collections.Generic;
using MyMellow.DbContext;
using MyMellow.Domain.Models;

namespace MyMellow.Seeder
{
    public static class Seed
    {
        public static void SeedSampleData(this MyMellowContext context)
        {
            var taskFlows = new List<TaskFlow>
            {
                new TaskFlow
                {
                    Name = "To-Do",
                    Phases = new List<TaskPhase>
                    {
                        new TaskPhase
                        {
                            Name = "New",
                            OrderNumber = 1
                        },
                        new TaskPhase
                        {
                            Name = "In Progress",
                            OrderNumber = 2
                        },
                        new TaskPhase
                        {
                            Name = "Complete",
                            OrderNumber = 3
                        },
                        new TaskPhase
                        {
                            Name = "Cancelled",
                            OrderNumber = 4
                        }
                    },
                    Tasks = new List<Task>
                    {
                        new Task
                        {
                            Name = "Shit",
                            OrderNumber = 1
                        },
                        new Task
                        {
                            Name = "Shower",
                            OrderNumber = 2
                        },
                        new Task
                        {
                            Name = "Shave",
                            OrderNumber = 3
                        }
                    }
                }
            };

            context.TaskFlow.AddRange(taskFlows);
            context.SaveChanges();
        }
    }
}