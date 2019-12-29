using System;
using Microsoft.EntityFrameworkCore;
using MyMellow.Domain.Models;

namespace MyMellow.DbContext.ModelConfigurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Schedule> builder)
        {
            builder
                .Property(s => s.StartAt)
                .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            builder
                .Property(s => s.EndAt)
                .HasConversion(v => v, v => v != null ? DateTime.SpecifyKind((DateTime)v, DateTimeKind.Utc) : (DateTime?)null);

        }
    }
}