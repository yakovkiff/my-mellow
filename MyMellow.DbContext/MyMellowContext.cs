using Microsoft.EntityFrameworkCore;
using MyMellow.DbContext.ModelConfigurations;
using MyMellow.Domain.Models;

namespace MyMellow.DbContext
{
    public class MyMellowContext : Microsoft.EntityFrameworkCore.DbContext
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
        public DbSet<TaskSchedule> TaskSchedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskConfiguration).Assembly);
        }
    }

}