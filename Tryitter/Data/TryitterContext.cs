using System;
using Microsoft.EntityFrameworkCore;
using Tryitter.Models;
using Tryitter.Data.Mappings;

namespace Tryitter.Data
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
