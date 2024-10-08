﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Identity.migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CategoryID");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ParentCategoryID");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Core.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CourseID");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CategoryID");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Level")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<decimal?>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(10,2)")
                        .HasDefaultValueSql("0.00");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("ThumbnailURL");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("CourseId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Core.Entities.CourseContent", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ContentID");

                    b.Property<string>("ContentType")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CourseID");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("Sequence")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("ContentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Course_Content", (string)null);
                });

            modelBuilder.Entity("Core.Entities.CourseMaterial", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("MaterialID");

                    b.Property<int?>("CourseId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CourseID");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("FileType")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int?>("Sequence")
                        .HasColumnType("INTEGER");

                    b.HasKey("MaterialId");

                    b.HasIndex("CourseId");

                    b.ToTable("Course_Materials", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TextContent", b =>
                {
                    b.Property<int>("TextId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("TextID");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ContentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ContentID");

                    b.HasKey("TextId");

                    b.HasIndex("ContentId");

                    b.ToTable("Text_Contents", (string)null);
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("UserID");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("FirstName")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("LastName")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("UserId");

                    b.HasIndex(new[] { "Email" }, "IX_Users_Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.VideoContent", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("VideoID");

                    b.Property<int?>("ContentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ContentID");

                    b.Property<int?>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("VideoURL");

                    b.HasKey("VideoId");

                    b.HasIndex("ContentId");

                    b.ToTable("Video_Contents", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.HasOne("Core.Entities.Category", "ParentCategory")
                        .WithMany("InverseParentCategory")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Core.Entities.Course", b =>
                {
                    b.HasOne("Core.Entities.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.Entities.CourseContent", b =>
                {
                    b.HasOne("Core.Entities.Course", "Course")
                        .WithMany("CourseContents")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Core.Entities.CourseMaterial", b =>
                {
                    b.HasOne("Core.Entities.Course", "Course")
                        .WithMany("CourseMaterials")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Core.Entities.TextContent", b =>
                {
                    b.HasOne("Core.Entities.CourseContent", "Content")
                        .WithMany("TextContents")
                        .HasForeignKey("ContentId");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Core.Entities.VideoContent", b =>
                {
                    b.HasOne("Core.Entities.CourseContent", "Content")
                        .WithMany("VideoContents")
                        .HasForeignKey("ContentId");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("InverseParentCategory");
                });

            modelBuilder.Entity("Core.Entities.Course", b =>
                {
                    b.Navigation("CourseContents");

                    b.Navigation("CourseMaterials");
                });

            modelBuilder.Entity("Core.Entities.CourseContent", b =>
                {
                    b.Navigation("TextContents");

                    b.Navigation("VideoContents");
                });
#pragma warning restore 612, 618
        }
    }
}
