using Microsoft.EntityFrameworkCore;
using MyMellow.Domain.Models;

namespace MyMellow.Infrastructure.DbContexts
{
    public class MyMellowContext : DbContext
    {
        public MyMellowContext(DbContextOptions<MyMellowContext> options) : base(options)
        {
        }

        public DbSet<Task> Task { get; set; }
    }

}