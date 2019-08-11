using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMellow.Domain.Models;

namespace ModelConfigurations
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
        }
    }

}
