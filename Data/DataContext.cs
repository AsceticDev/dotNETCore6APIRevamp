using dotNETCoreAPIRevamp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNETCoreAPIRevamp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //new DbInitializer(builder).Seed();
        }

    }
}
