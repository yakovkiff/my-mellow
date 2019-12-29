using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

namespace MyMellow.DbContext.ModelConfigurations
{
    public class TaskFlowTemplatePhaseConfiguration : IEntityTypeConfiguration<TaskFlowTemplatePhase>
    {
        public void Configure(EntityTypeBuilder<TaskFlowTemplatePhase> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}