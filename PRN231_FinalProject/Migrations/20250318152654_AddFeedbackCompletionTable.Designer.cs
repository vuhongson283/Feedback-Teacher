﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PRN231_FinalProject.Models;

#nullable disable

namespace PRN231_FinalProject.Migrations
{
    [DbContext(typeof(FeedbackSystemContext))]
    [Migration("20250318152654_AddFeedbackCompletionTable")]
    partial class AddFeedbackCompletionTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PRN231_FinalProject.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"), 1L, 1);

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.ClassAssignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId")
                        .HasName("PK__ClassAss__32499E777083E996");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassAssignments");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.FeedbackAnswer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SubmittedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("AnswerId")
                        .HasName("PK__Feedback__D4825004C0714B59");

                    b.HasIndex("FormId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("StudentId");

                    b.ToTable("FeedbackAnswers");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.FeedbackForm", b =>
                {
                    b.Property<int>("FormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormId"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("FormId")
                        .HasName("PK__Feedback__FB05B7DDF5CBBB88");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("FeedbackForms");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.FeedbackQuestion", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"), 1L, 1);

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("QuestionId")
                        .HasName("PK__Feedback__0DC06FACBCAA75EB");

                    b.ToTable("FeedbackQuestions");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.StudentClass", b =>
                {
                    b.Property<int>("StudentClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentClassId"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("StudentClassId");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentClass", (string)null);
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D10534999D6412")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.ClassAssignment", b =>
                {
                    b.HasOne("PRN231_FinalProject.Models.Class", "Class")
                        .WithMany("ClassAssignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ClassAssi__Class__634EBE90");

                    b.HasOne("PRN231_FinalProject.Models.Subject", "Subject")
                        .WithMany("ClassAssignments")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ClassAssi__Subje__6442E2C9");

                    b.HasOne("PRN231_FinalProject.Models.User", "Teacher")
                        .WithMany("ClassAssignments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ClassAssi__Teach__65370702");

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.FeedbackAnswer", b =>
                {
                    b.HasOne("PRN231_FinalProject.Models.FeedbackForm", "Form")
                        .WithMany("FeedbackAnswers")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__FeedbackA__FormI__74794A92");

                    b.HasOne("PRN231_FinalProject.Models.FeedbackQuestion", "Question")
                        .WithMany("FeedbackAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__FeedbackA__Quest__76619304");

                    b.HasOne("PRN231_FinalProject.Models.User", "Student")
                        .WithMany("FeedbackAnswers")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK__FeedbackA__Stude__756D6ECB");

                    b.Navigation("Form");

                    b.Navigation("Question");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.FeedbackForm", b =>
                {
                    b.HasOne("PRN231_FinalProject.Models.Class", "Class")
                        .WithMany("FeedbackForms")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__FeedbackF__Class__6CD828CA");

                    b.HasOne("PRN231_FinalProject.Models.Subject", "Subject")
                        .WithMany("FeedbackForms")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__FeedbackF__Subje__6DCC4D03");

                    b.HasOne("PRN231_FinalProject.Models.User", "Teacher")
                        .WithMany("FeedbackForms")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__FeedbackF__Teach__6EC0713C");

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.StudentClass", b =>
                {
                    b.HasOne("PRN231_FinalProject.Models.Class", "Class")
                        .WithMany("StudentClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__StudentCl__Class__690797E6");

                    b.HasOne("PRN231_FinalProject.Models.User", "Student")
                        .WithMany("StudentClasses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__StudentCl__Stude__681373AD");

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.Class", b =>
                {
                    b.Navigation("ClassAssignments");

                    b.Navigation("FeedbackForms");

                    b.Navigation("StudentClasses");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.FeedbackForm", b =>
                {
                    b.Navigation("FeedbackAnswers");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.FeedbackQuestion", b =>
                {
                    b.Navigation("FeedbackAnswers");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.Subject", b =>
                {
                    b.Navigation("ClassAssignments");

                    b.Navigation("FeedbackForms");
                });

            modelBuilder.Entity("PRN231_FinalProject.Models.User", b =>
                {
                    b.Navigation("ClassAssignments");

                    b.Navigation("FeedbackAnswers");

                    b.Navigation("FeedbackForms");

                    b.Navigation("StudentClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
