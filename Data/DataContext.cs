using dotNETCoreAPIRevamp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotNETCoreAPIRevamp.Data
{
    public class DataContext : IdentityDbContext<IdentityUser> 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //new DbInitializer(builder).Seed();
            base.OnModelCreating(builder);
        }

    }
}
