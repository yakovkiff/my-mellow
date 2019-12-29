using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

namespace MyMellow.DbContext.ModelConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note> 
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Content)
                .HasMaxLength(4000);
            
            builder
                .HasMany(n => n.TagMaps)
                .WithOne(m => m.Note)
                .HasForeignKey(m => m.NoteId);

            builder
                .HasMany(n => n.Schedules)
                .WithOne(s => s.Note)
                .HasForeignKey(s => s.NoteId);
        }
    }

}
