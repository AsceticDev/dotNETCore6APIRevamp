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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //new DbInitializer(builder).Seed();

            //Many-Many
            //PostTag
            builder.Entity<PostTag>()
                .HasKey(pt => new { pt.PostId, pt.TagName });

            builder.Entity<PostTag>()
                .HasOne(p => p.Tag)
                .WithMany(p => p.PostTag)
                .HasForeignKey(p => p.TagName);

            builder.Entity<PostTag>()
                .HasOne(t => t.Post)
                .WithMany(t => t.PostTag)
                .HasForeignKey(t=>t.PostId);

            //One To Many
            //User(one)/Post(many)
            builder.Entity<Post>()
                .HasOne<AppUser>(u => u.User)
                .WithMany(g => g.Posts)
                .HasForeignKey(s => s.UserId);
            //User(one)/Tag(many)
            builder.Entity<Tag>()
                .HasOne<AppUser>(u => u.User)
                .WithMany(g => g.CreatedPostTags)
                .HasForeignKey(s => s.UserId);



            base.OnModelCreating(builder);

        }

    }
}
