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
                    Title = "shiva"
                });

            });

            _builder.Entity<Post>(a =>
            {
                a.HasData(new Post
                {
                    Id = 1,
                    Title = "bhairava"
                });
            });

            _builder.Entity<Post>(a =>
            {
                a.HasData(new Post
                {
                    Id = 2,
                    Title = "Shamshaan"
                });
            });

            _builder.Entity<Post>(a =>
            {
                a.HasData(new Post
                {
                    Id = 3,
                    Title = "Bhang"
                });
            });

            _builder.Entity<Post>(a =>
            {
                a.HasData(new Post
                {
                    Id = 4,
                    Title = "Prasad"
                });
            });

        }
    }
}
