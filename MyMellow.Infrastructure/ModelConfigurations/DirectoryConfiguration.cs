using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

public class DirectoryConfiguration : IEntityTypeConfiguration<Directory> 
{
    public void Configure(EntityTypeBuilder<Directory> builder)
    {
        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(50);
    }
}