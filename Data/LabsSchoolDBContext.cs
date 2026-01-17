using System;
using System.Collections.Generic;
using LabsSchoolDBApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LabsSchoolDBApp.Data;

public partial class LabsSchoolDBContext : DbContext
{
    public LabsSchoolDBContext()
    {
    }

    public LabsSchoolDBContext(DbContextOptions<LabsSchoolDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassCourse> ClassCourses { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Database = LabsSchoolDB; Integrated Security = True; Trust Server Certificate = True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassCode).HasName("PK__Class__2ECD4A5443BABE99");

            entity.ToTable("Class");

            entity.Property(e => e.ClassCode)
                .HasMaxLength(4)
                .IsFixedLength();

            entity.HasOne(d => d.ClassTeacherNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.ClassTeacher)
                .HasConstraintName("Class_Teacher");
        });

        modelBuilder.Entity<ClassCourse>(entity =>
        {
            entity.HasKey(e => e.ClassCourseId).HasName("PK__Class_Co__253BE251465D0C7C");

            entity.ToTable("Class_Course");

            entity.Property(e => e.ClassCourseId).HasColumnName("Class_CourseId");
            entity.Property(e => e.ClassCode)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.CourseCode)
                .HasMaxLength(5)
                .IsFixedLength();

            entity.HasOne(d => d.ClassCodeNavigation).WithMany(p => p.ClassCourses)
                .HasForeignKey(d => d.ClassCode)
                .HasConstraintName("Class_Course_Class");

            entity.HasOne(d => d.CourseCodeNavigation).WithMany(p => p.ClassCourses)
                .HasForeignKey(d => d.CourseCode)
                .HasConstraintName("Class_Course_Course");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseCode).HasName("PK__Course__FC00E00129408921");

            entity.ToTable("Course");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.CourseName).HasMaxLength(100);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("Course_Teacher");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED11EF2BE5");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentName).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11AE3C5DF7");

            entity.ToTable("Employee");

            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("Employee_Department");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grade__54F87A575B26D530");

            entity.ToTable("Grade");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Grade1).HasColumnName("Grade");

            entity.HasOne(d => d.CourseCodeNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.CourseCode)
                .HasConstraintName("Grade_Course");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("Grade_Student");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Grades)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("Grade_Teacher");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99D891828D");

            entity.ToTable("Student");

            entity.Property(e => e.ClassCode)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PersonalNr)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.ClassCodeNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassCode)
                .HasConstraintName("Student_Class");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
