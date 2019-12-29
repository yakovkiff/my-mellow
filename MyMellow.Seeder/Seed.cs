using System;
using System.Collections.Generic;
using MyMellow.DbContext;
using MyMellow.Domain.Models;

namespace MyMellow.Seeder
{
    public static class Seed
    {
        public static void SeedSampleData(this MyMellowContext context)
        {
            var now = DateTime.UtcNow;

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

            // var dailyFlow = new TaskFlow
            // {
            //     Name = "Daily Flows",
            //     ChildMaps = new List<TaskFlowInTaskFlowMap>
            //     {
            //         new TaskFlowInTaskFlowMap
            //         {
            //             Parent = morningFlow,
            //             OrderNumber = 1
            //         },
            //         new TaskFlowInTaskFlowMap
            //         {
            //             Parent = eveningFlow,
            //             OrderNumber = 2
            //         }
            //     }
            // };

            var doMorningStuff = new Task
            {
                Name = "Do Morning Stuff",
                Schedules = new List<TaskSchedule>
                {
                    new TaskSchedule
                    {
                        Schedule = new Schedule
                        {
                            StartAt = new DateTime(now.Year, now.Month, now.Day, 7, 0, 0, DateTimeKind.Utc), // 7:00am
                            EndAt = new DateTime(now.Year, now.Month, now.Day, 8, 10, 0, DateTimeKind.Utc), // 8:10am
                        }
                    }
                },
                ChildTaskFlowMaps = new List<TaskFlowForTaskMap>
                {
                    new TaskFlowForTaskMap
                    {
                        ChildFlow = morningFlow
                    },
                    new TaskFlowForTaskMap
                    {
                        ChildFlow = eveningFlow
                    }
                }
            };

            var doEveningStuff = new Task
            {
                Name = "Do Evening Stuff",
                ChildTaskFlowMaps = new List<TaskFlowForTaskMap>
                {
                    new TaskFlowForTaskMap
                    {
                        ChildFlow = eveningFlow
                    }
                }
            };

            var organizeDay = new Task
            {
                Name = "Do Daily Things",
                Schedules = new List<TaskSchedule>
                {
                    new TaskSchedule
                    {
                        Schedule = new Schedule
                        {
                            StartAt = DateTime.UtcNow, // 5:00am
                            EndAt = DateTime.UtcNow, // 4:59am next day
                            RepeatEvery = TimeSpan.FromDays(1) // single day
                        }
                    }
                },
            };

            var childTaskMaps = new List<TaskMap>
            {
                new TaskMap
                {
                    Child = doMorningStuff,
                    Parent = organizeDay
                },
                new TaskMap
                {
                    Child = doEveningStuff,
                    Parent = organizeDay
                }
            };

            context.Task.Add(organizeDay);
            context.TaskMap.AddRange(childTaskMaps);
            context.SaveChanges();
        }
    }
}