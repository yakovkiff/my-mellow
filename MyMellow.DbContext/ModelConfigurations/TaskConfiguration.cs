using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

namespace MyMellow.DbContext.ModelConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task> 
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(f => f.ParentTaskFlowMaps)
                .WithOne(m => m.Task)
                .HasForeignKey(m => m.TaskId);

            builder
                .HasMany(f => f.ChildTaskFlowMaps)
                .WithOne(m => m.ParentTask)
                .HasForeignKey(m => m.TaskId);
            
            builder
                .HasMany(t => t.ParentTaskMaps)
                .WithOne(m => m.Parent)
                .HasForeignKey(m => m.ParentId);

            builder
                .HasMany(t => t.ChildTaskMaps)
                .WithOne(m => m.Child)
                .HasForeignKey(m => m.ChildId);

            builder
                .HasMany(t => t.TagMaps)
                .WithOne(m => m.Task)
                .HasForeignKey(m => m.TaskId);
            
            builder
                .HasMany(t => t.Schedules)
                .WithOne(s => s.Task)
                .HasForeignKey(s => s.TaskId);

        }
    }

}
