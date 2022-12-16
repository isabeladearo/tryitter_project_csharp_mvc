using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id);

            builder.Property(p => p.Title).HasMaxLength(80);

            builder.Property(p => p.Body).HasMaxLength(300);

            builder.Property(p => p.Image);

            builder.Property(p => p.CreateDate).HasMaxLength(60).HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.LastUpdateDate).HasMaxLength(60).HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(s => s.Student)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

