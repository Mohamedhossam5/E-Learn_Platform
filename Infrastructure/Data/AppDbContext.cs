using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseContent> CourseContents { get; set; }

    public virtual DbSet<CourseMaterial> CourseMaterials { get; set; }

    public virtual DbSet<TextContent> TextContents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VideoContent> VideoContents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=../ELearningPlatform.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasColumnType("VARCHAR(255)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME");
            entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryID");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory).HasForeignKey(d => d.ParentCategoryId);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CourseName).HasColumnType("VARCHAR(255)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME");
            entity.Property(e => e.Language).HasColumnType("VARCHAR(100)");
            entity.Property(e => e.Level).HasColumnType("VARCHAR(50)");
            entity.Property(e => e.Price)
                .HasDefaultValueSql("0.00")
                .HasColumnType("DECIMAL(10,2)");
            entity.Property(e => e.ThumbnailUrl)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("ThumbnailURL");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<CourseContent>(entity =>
        {
            entity.HasKey(e => e.ContentId);

            entity.ToTable("Course_Content");

            entity.Property(e => e.ContentId).HasColumnName("ContentID");
            entity.Property(e => e.ContentType).HasColumnType("VARCHAR(50)");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME");
            entity.Property(e => e.Title).HasColumnType("VARCHAR(255)");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseContents).HasForeignKey(d => d.CourseId);
        });

        modelBuilder.Entity<CourseMaterial>(entity =>
        {
            entity.HasKey(e => e.MaterialId);

            entity.ToTable("Course_Materials");

            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME");
            entity.Property(e => e.FilePath).HasColumnType("VARCHAR(255)");
            entity.Property(e => e.FileType).HasColumnType("VARCHAR(50)");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseMaterials).HasForeignKey(d => d.CourseId);
        });

        modelBuilder.Entity<TextContent>(entity =>
        {
            entity.HasKey(e => e.TextId);

            entity.ToTable("Text_Contents");

            entity.Property(e => e.TextId).HasColumnName("TextID");
            entity.Property(e => e.ContentId).HasColumnName("ContentID");

            entity.HasOne(d => d.Content).WithMany(p => p.TextContents).HasForeignKey(d => d.ContentId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Users_Email").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME");
            entity.Property(e => e.Email).HasColumnType("VARCHAR(255)");
            entity.Property(e => e.FirstName).HasColumnType("VARCHAR(255)");
            entity.Property(e => e.LastName).HasColumnType("VARCHAR(255)");
            entity.Property(e => e.PasswordHash).HasColumnType("VARCHAR(255)");
            entity.Property(e => e.ProfilePicture).HasColumnType("VARCHAR(255)");
            entity.Property(e => e.Role).HasColumnType("VARCHAR(50)");
        });

        modelBuilder.Entity<VideoContent>(entity =>
        {
            entity.HasKey(e => e.VideoId);

            entity.ToTable("Video_Contents");

            entity.Property(e => e.VideoId).HasColumnName("VideoID");
            entity.Property(e => e.ContentId).HasColumnName("ContentID");
            entity.Property(e => e.VideoUrl)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("VideoURL");

            entity.HasOne(d => d.Content).WithMany(p => p.VideoContents).HasForeignKey(d => d.ContentId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
