using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

namespace MyMellow.DbContext.ModelConfigurations
{
    public class TaskPhaseConfiguration : IEntityTypeConfiguration<TaskPhase> 
    {
        public void Configure(EntityTypeBuilder<TaskPhase> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

}
