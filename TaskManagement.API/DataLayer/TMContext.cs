using Microsoft.EntityFrameworkCore;
using TaskManagement.API.DataLayer.Entities;

namespace TaskManagement.API.DataLayer
{
    public class TMContext : DbContext
    {
        public TMContext(DbContextOptions<TMContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public DbSet<TMTask> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        

    }
}
