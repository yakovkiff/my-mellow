using System.Collections.Generic;
using MyMellow.DbContext;
using MyMellow.Domain.Models;

namespace MyMellow.Seeder
{
    public static class Seed
    {
        public static void SeedSampleData(this MyMellowContext context)
        {
            var shit = new Task
            {
                Name = "Shit"
            };

            var shower = new Task
            {
                Name = "Shower"
            };

            var shave = new Task
            {
                Name = "Shave"
            };

            var morningFlow = new TaskFlow
            {
                Name = "Morning Flow",
                TaskInTaskFlowMaps = new List<TaskInTaskFlowMap>
                {
                    new TaskInTaskFlowMap
                    {
                        Task = shit,
                        OrderNumber = 1
                    },
                    new TaskInTaskFlowMap
                    {
                        Task = shower,
                        OrderNumber = 2
                    },
                    new TaskInTaskFlowMap
                    {
                        Task = shave,
                        OrderNumber = 3
                    }
                }
            };

            var eveningFlow = new TaskFlow
            {
                Name = "Evening Flow"
            };

            var dailyFlow = new TaskFlow
            {
                Name = "Daily Flows",
                ChildMaps = new List<TaskFlowInTaskFlowMap>
                {
                    new TaskFlowInTaskFlowMap
                    {
                        Parent = morningFlow,
                        OrderNumber = 1
                    },
                    new TaskFlowInTaskFlowMap
                    {
                        Parent = eveningFlow,
                        OrderNumber = 2
                    }
                }
            };

            var organizeDay = new Task
            {
                Name = "Organize Day",
                ChildTaskFlowMaps = new List<TaskFlowForTaskMap>
                {
                    new TaskFlowForTaskMap
                    {
                        Flow = dailyFlow
                    }
                }
            };

            context.Task.Add(organizeDay);
            context.SaveChanges();
        }
    }
}