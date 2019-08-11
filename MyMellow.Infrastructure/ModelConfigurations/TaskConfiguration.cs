using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

namespace ModelConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task> 
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

}
