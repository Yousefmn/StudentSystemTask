using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;

namespace P01_StudentSystem.Data;

public partial class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {
    }

    public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
        : base(options)
    {
    }
    public DbSet<StudentCourse> StudentsCourses { get; set; }
    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=3MOELJO\\SQLEXPRESS;Database=StudentSystem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
    .Property(c => c.Name)
    .HasMaxLength(80)
    .IsUnicode();

        modelBuilder.Entity<Course>()
            .Property(c => c.Description)
            .IsUnicode()
            .IsRequired(false);

        modelBuilder.Entity<Resource>()
            .Property(r => r.Name)
            .HasMaxLength(50)
            .IsUnicode();

        modelBuilder.Entity<Resource>()
            .Property(r => r.Url)
            .IsUnicode(false);

        modelBuilder.Entity<HomeworkSubmission>()
            .Property(h => h.Content)
            .IsUnicode(false);

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<HomeworkSubmission>(entity =>
        {
            entity.HasIndex(e => e.CourseId, "IX_HomeworkSubmissions_CourseId");

            entity.HasIndex(e => e.StudentId, "IX_HomeworkSubmissions_StudentId");

            entity.HasOne(d => d.Course).WithMany(p => p.HomeworkSubmissions).HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Student).WithMany(p => p.HomeworkSubmissions).HasForeignKey(d => d.StudentId);
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasIndex(e => e.CourseId, "IX_Resources_CourseId");

            entity.HasOne(d => d.Course).WithMany(p => p.Resources).HasForeignKey(d => d.CourseId);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);

            modelBuilder.Entity<StudentCourse>()
     .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

        });

    }

}
