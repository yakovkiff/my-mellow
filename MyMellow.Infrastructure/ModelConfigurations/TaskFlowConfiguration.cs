using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

namespace ModelConfigurations
{
    public class TaskFlowConfiguration : IEntityTypeConfiguration<TaskFlow> 
    {
        public void Configure(EntityTypeBuilder<TaskFlow> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

}
