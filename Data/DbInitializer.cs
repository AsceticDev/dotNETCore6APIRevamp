using dotNETCoreAPIRevamp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNETCoreAPIRevamp.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;
        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Post>(a =>
            {
                a.HasData(new Post
                {
                    Id = 0,
                    Name = "shiva"
                });

            });

            _builder.Entity<Post>(a =>
            {
                a.HasData(new Post
                {
                    Id = 1,
                    Name = "bhairava"
                });
            });

            _builder.Entity<Post>(a =>
            {
                a.HasData(new Post
                {
                    Id = 2,
                    Name = "Shamshaan Ghat"
                });
            });

            _builder.Entity<Post>(a =>
            {
                a.HasData(new Post
                {
                    Id = 3,
                    Name = "bhang"
                });
            });

            _builder.Entity<Post>(a =>
            {
                a.HasData(new Post
                {
                    Id = 4,
                    Name = "prasad"
                });
            });

        }
    }
}
