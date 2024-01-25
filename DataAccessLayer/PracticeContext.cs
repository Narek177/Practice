using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public partial class PracticeContext : DbContext
{
    public PracticeContext()
    {
    }

    public PracticeContext(DbContextOptions<PracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogTag> BlogTags { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blog");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<BlogTag>(entity =>
        {
            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Blog).WithMany(p => p.BlogTags)
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogTags_Blog");

            entity.HasOne(d => d.Tag).WithMany(p => p.BlogTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogTags_Tag");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Comment");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Blog).WithMany()
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Blog");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_User");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("Tag");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
