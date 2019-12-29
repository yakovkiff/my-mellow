using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

namespace MyMellow.DbContext.ModelConfigurations
{    public class DirectoryConfiguration : IEntityTypeConfiguration<Directory> 
    {
        public void Configure(EntityTypeBuilder<Directory> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(d => d.Children)
                .WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId);
            
            builder
                .HasMany(d => d.Notes)
                .WithOne(n => n.Directory)
                .HasForeignKey(n => n.DirectoryId);

            builder
                .HasMany(d => d.TagMaps)
                .WithOne(m => m.Directory)
                .HasForeignKey(m => m.DirectoryId);

        }
    }

}
