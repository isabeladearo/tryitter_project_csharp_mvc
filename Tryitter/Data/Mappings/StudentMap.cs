using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tryitter.Models;

namespace Tryitter.Data.Mappings
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired()
                .ValueGeneratedNever()
                .UseIdentityColumn();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(160);

            builder.Property(s => s.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.Module)
                .IsRequired();

            builder.Property(s => s.Status)
                .IsRequired();
        }
    }
}

