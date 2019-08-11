using Microsoft.EntityFrameworkCore;
using MyMellow.Domain.Models;

namespace MyMellow.Infrastructure
{
    public class MyMellowContext : DbContext
    {
        public MyMellowContext(DbContextOptions<MyMellowContext> options) : base(options)
        {
        }

        public DbSet<Directory> Directory {get; set;}
        public DbSet<Note> Note { get; set; }
        public DbSet<NoteSchedule> NoteSchedule { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TagDirectoryMap> TagDirectoryMap { get; set; }
        public DbSet<TagNoteMap> TagNoteMap { get; set; }
        public DbSet<TagTaskMap> TagTaskMap { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<TaskFlow> TaskFlow { get; set; }
        public DbSet<TaskMap> TaskMap { get; set; }
        public DbSet<TaskPhase> TaskPhase { get; set; }
        public DbSet<TaskSchedule> TaskSchedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DirectoryConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new TaskFlowConfiguration());
            modelBuilder.ApplyConfiguration(new TaskPhaseConfiguration());

            // modelBuilder.Entity<Directory>()
            //     .HasMany(d => d.Children)
            //     .WithOne(c => c.Parent);
            
            // modelBuilder.Entity<Directory>()
            //     .HasMany(d => d.Notes)
            //     .WithOne(n => n.Directory);

            // modelBuilder
        }
    }

}