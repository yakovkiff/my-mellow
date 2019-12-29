using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

namespace MyMellow.DbContext.ModelConfigurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag> 
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }

}