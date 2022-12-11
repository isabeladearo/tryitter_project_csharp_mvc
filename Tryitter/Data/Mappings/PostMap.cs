using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tryitter.Models;

namespace Tryitter.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedNever()
                .UseIdentityColumn();

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(p => p.Body)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(p => p.Image)
                .IsRequired(false);

            builder.Property(p => p.CreateDate)
                .IsRequired()
                .HasMaxLength(60)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.LastUpdateDate)
                .IsRequired()
                .HasMaxLength(60)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(s => s.Student)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

