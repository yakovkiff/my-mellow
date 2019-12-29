using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

namespace MyMellow.DbContext.ModelConfigurations
{
    public class TaskFlowConfiguration : IEntityTypeConfiguration<TaskFlow> 
    {
        public void Configure(EntityTypeBuilder<TaskFlow> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(f => f.TaskInTaskFlowMaps)
                .WithOne(m => m.Flow)
                .HasForeignKey(m => m.TaskFlowId);

            builder
                .HasMany(f => f.TaskFlowForTaskMaps)
                .WithOne(m => m.ChildFlow)
                .HasForeignKey(m => m.TaskFlowId);

            builder
                .HasMany(f => f.ParentMaps)
                .WithOne(m => m.Parent)
                .HasForeignKey(m => m.ParentId);

            builder
                .HasMany(f => f.ChildMaps)
                .WithOne(m => m.Child)
                .HasForeignKey(m => m.ChildId);

        }
    }

}
