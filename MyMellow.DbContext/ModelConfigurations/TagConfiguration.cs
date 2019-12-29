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
            
            builder
                .HasMany(t => t.TaskMaps)
                .WithOne(m => m.Tag)
                .HasForeignKey(m => m.TagId);

            builder
                .HasMany(t => t.NoteMaps)
                .WithOne(m => m.Tag)
                .HasForeignKey(m => m.TagId);

            builder
                .HasMany(t => t.DirectoryMaps)
                .WithOne(m => m.Tag)
                .HasForeignKey(m => m.TagId);

        }
    }

}
