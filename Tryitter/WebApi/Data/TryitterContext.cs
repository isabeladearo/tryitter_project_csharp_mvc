using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Data.Mappings;

namespace WebApi.Data
{
    public class TryitterContext : DbContext
    {
        public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new StudentMap());
            mb.ApplyConfiguration(new PostMap());
        }
    }
}
