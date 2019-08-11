using Microsoft.EntityFrameworkCore;
using ModelConfigurations;
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

            #region associations

            modelBuilder.Entity<Directory>()
                .HasMany(d => d.Children)
                .WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId);
            
            modelBuilder.Entity<Directory>()
                .HasMany(d => d.Notes)
                .WithOne(n => n.Directory)
                .HasForeignKey(n => n.DirectoryId);

            modelBuilder.Entity<Directory>()
                .HasMany(d => d.TagMaps)
                .WithOne(m => m.Directory)
                .HasForeignKey(m => m.DirectoryId);

            modelBuilder.Entity<Note>()
                .HasMany(n => n.TagMaps)
                .WithOne(m => m.Note)
                .HasForeignKey(m => m.NoteId);

            modelBuilder.Entity<Note>()
                .HasMany(n => n.Schedules)
                .WithOne(s => s.Note)
                .HasForeignKey(s => s.NoteId);

            modelBuilder.Entity<TaskFlow>()
                .HasMany(f => f.Phases)
                .WithOne(ph => ph.TaskFlow)
                .HasForeignKey(ph => ph.TaskFlowId);
            
            modelBuilder.Entity<TaskFlow>()
                .HasMany(f => f.Tasks)
                .WithOne(ph => ph.Flow)
                .HasForeignKey(ph => ph.TaskFlowId);
            
            modelBuilder.Entity<Task>()
                .HasMany(t => t.ParentMaps)
                .WithOne(m => m.Parent)
                .HasForeignKey(m => m.ParentId);

            modelBuilder.Entity<Task>()
                .HasMany(t => t.ChildMaps)
                .WithOne(m => m.Child)
                .HasForeignKey(m => m.ChildId);

            modelBuilder.Entity<Task>()
                .HasMany(t => t.TagMaps)
                .WithOne(m => m.Task)
                .HasForeignKey(m => m.TaskId);
            
            modelBuilder.Entity<Task>()
                .HasMany(t => t.Schedules)
                .WithOne(s => s.Task)
                .HasForeignKey(s => s.TaskId);
            
            modelBuilder.Entity<Tag>()
                .HasMany(t => t.TaskMaps)
                .WithOne(m => m.Tag)
                .HasForeignKey(m => m.TagId);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.NoteMaps)
                .WithOne(m => m.Tag)
                .HasForeignKey(m => m.TagId);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.DirectoryMaps)
                .WithOne(m => m.Tag)
                .HasForeignKey(m => m.TagId);
            
            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.Notes)
                .WithOne(n => n.Schedule)
                .HasForeignKey(n => n.ScheduleId);

            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.Tasks)
                .WithOne(t => t.Schedule)
                .HasForeignKey(t => t.ScheduleId);
            
            #endregion
        }
    }

}