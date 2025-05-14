using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRN231_FinalProject.Models
{
    public partial class FeedbackSystemContext : DbContext
    {
        public FeedbackSystemContext()
        {
        }

        public FeedbackSystemContext(DbContextOptions<FeedbackSystemContext> options)
            : base(options)
        {
        }
 
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<ClassAssignment> ClassAssignments { get; set; } = null!;
        public virtual DbSet<FeedbackAnswer> FeedbackAnswers { get; set; } = null!;
        public virtual DbSet<FeedbackForm> FeedbackForms { get; set; } = null!;
        public virtual DbSet<FeedbackQuestion> FeedbackQuestions { get; set; } = null!;
        public virtual DbSet<StudentClass> StudentClasses { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = FeedbackSystem;uid=sa;pwd=123;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassName).HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ClassAssignment>(entity =>
            {
                entity.HasKey(e => e.AssignmentId)
                    .HasName("PK__ClassAss__32499E777083E996");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassAssignments)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__ClassAssi__Class__634EBE90");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ClassAssignments)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__ClassAssi__Subje__6442E2C9");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.ClassAssignments)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__ClassAssi__Teach__65370702");
            });

            modelBuilder.Entity<FeedbackAnswer>(entity =>
            {
                entity.HasKey(e => e.AnswerId)
                    .HasName("PK__Feedback__D4825004C0714B59");

                entity.Property(e => e.Answer).HasMaxLength(50);

                entity.Property(e => e.SubmittedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FeedbackAnswers)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK__FeedbackA__FormI__74794A92");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.FeedbackAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__FeedbackA__Quest__76619304");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.FeedbackAnswers)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeedbackA__Stude__756D6ECB");
            });

            modelBuilder.Entity<FeedbackForm>(entity =>
            {
                entity.HasKey(e => e.FormId)
                    .HasName("PK__Feedback__FB05B7DDF5CBBB88");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.FeedbackForms)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__FeedbackF__Class__6CD828CA");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.FeedbackForms)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__FeedbackF__Subje__6DCC4D03");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.FeedbackForms)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__FeedbackF__Teach__6EC0713C");
            });

            modelBuilder.Entity<FeedbackQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__Feedback__0DC06FACBCAA75EB");

                entity.Property(e => e.QuestionText).HasMaxLength(1000);
            });

            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.ToTable("StudentClass");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentClasses)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__StudentCl__Class__690797E6");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentClasses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentCl__Stude__681373AD");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SubjectName).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534999D6412")
                    .IsUnique();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
