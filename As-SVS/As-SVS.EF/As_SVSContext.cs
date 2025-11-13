using System;
using System.Collections.Generic;
using As_SVS.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace As_SVS.EF;

public partial class As_SVSContext : IdentityDbContext<ApplicationUser>
{
    public As_SVSContext()
    {
    }

    public As_SVSContext(DbContextOptions<As_SVSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrolment> Enrolments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<QuestionOption> QuestionOptions { get; set; }

    public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

    public virtual DbSet<Quize> Quizes { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentLesson> StudentLessons { get; set; }

    public virtual DbSet<StudentQuizAttemp> StudentQuizAttemps { get; set; }

    public virtual DbSet<StudentRoom> StudentRooms { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=As-SVSDb;User Id=sa;Password=Sherlock@71;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.applicationUserId).HasColumnName("applicationUser_id");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");

            entity.HasOne(d => d.applicationUser).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.applicationUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admins_People");
        });

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CertificateNumber).HasColumnName("certificate_number");
            entity.Property(e => e.FileUrl).HasColumnName("file_url");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.IssuedAt).HasColumnName("issued_at");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Grade).WithMany(p => p.Certificates)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certificates_Grades");

            entity.HasOne(d => d.Student).WithMany(p => p.Certificates)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certificates_Students");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseCode)
                .HasMaxLength(50)
                .HasColumnName("course_code");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.IsProgressLimited).HasColumnName("is_progress_limited");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Enrolment>(entity =>
        {
            entity
                .ToTable("Enrolment");
            entity.HasKey(e => new { e.StudentId, e.CourseId });
            entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.EnrolmentDate).HasColumnName("enrolment_date");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrolment_Courses");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrolment_Students");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GradeLevel)
                .HasMaxLength(50)
                .HasColumnName("grade_level");
            entity.Property(e => e.Number)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("number");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("Lesson");

            entity.HasIndex(e => e.Number, "UQ_Lesson_Number").IsUnique();

            entity.HasIndex(e => e.CourseOrder, "UQ_Lesson_Order").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseOrder).HasColumnName("course_order");
            entity.Property(e => e.LessonDetails).HasColumnName("lesson_details");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(500)
                .HasColumnName("video_url");

            entity.HasOne(d => d.Module).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lesson_Module");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.MessageContent)
                .HasMaxLength(200)
                .HasColumnName("message_content");
            entity.Property(e => e.applicationUserId).HasColumnName("applicationUser_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.applicationUser).WithMany(p => p.Messages)
                .HasForeignKey(d => d.applicationUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_People");

            entity.HasOne(d => d.Room).WithMany(p => p.Messages)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Rooms");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.ToTable("Module");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Number).HasColumnName("number");

            entity.HasOne(d => d.Course).WithMany(p => p.Modules)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Module_Courses");
        });

        modelBuilder.Entity<QuestionOption>(entity =>
        {
            entity.ToTable("Question_Options");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
            entity.Property(e => e.Number)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("number");
            entity.Property(e => e.OptionText)
                .HasMaxLength(500)
                .HasColumnName("option_text");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionOptions)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Question_Options_Quiz_Questions");
        });

        modelBuilder.Entity<QuizQuestion>(entity =>
        {
            entity.ToTable("Quiz_Questions");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Question)
                .HasMaxLength(500)
                .HasColumnName("question");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizQuestions)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Quiz_Questions_Quizes");
        });

        modelBuilder.Entity<Quize>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseOrder).HasColumnName("course_order");
            entity.Property(e => e.IsPassRequiered).HasColumnName("is_pass_requiered");
            entity.Property(e => e.MinPassScore).HasColumnName("min_pass_score");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Number).HasColumnName("number");

            entity.HasOne(d => d.Module).WithMany(p => p.Quizes)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Quizes_Module");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Average).HasColumnName("average");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.MotherName)
                .HasMaxLength(100)
                .HasColumnName("mother_name");
            entity.Property(e => e.applicationUserId).HasColumnName("applicationUser_id");
            entity.Property(e => e.StudentCode)
                .HasMaxLength(50)
                .HasColumnName("student_code");

            entity.HasOne(d => d.Grade).WithMany(p => p.Students)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Grades");

            entity.HasOne(d => d.applicationUser).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.applicationUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_People");
        });

        modelBuilder.Entity<StudentLesson>(entity =>
        {
            entity
                .HasKey(e => new {e.LessonId,e.StudentId});
            entity.ToTable("Student_Lessons");
            entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Lesson).WithMany()
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Lesson_Lesson");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Lesson_Students");
        });

        modelBuilder.Entity<StudentQuizAttemp>(entity =>
        {
            entity
                .HasKey(e => new {e.QuizId,e.StudentId});
            entity.ToTable("Student_Quiz_Attemp");

            entity.Property(e => e.AttempDate).HasColumnName("attemp_date");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.ScoreAchived).HasColumnName("score_achived");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Quiz).WithMany()
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Quiz_Attemp_Quizes");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Quiz_Attemp_Students");
        });

        modelBuilder.Entity<StudentRoom>(entity =>
        {
            entity
                .ToTable("Student_Room");
            entity.HasKey(e => new {e.RoomId,e.StudentId});

            entity.Property(e => e.JoinDate).HasColumnName("join_date");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Room).WithMany()
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Room_Rooms");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Feedbacks)
                .HasMaxLength(500)
                .HasColumnName("feedbacks");
            entity.Property(e => e.GradesId).HasColumnName("grades_id");
            entity.Property(e => e.applicationUserId).HasColumnName("applicationUser_id");
            entity.Property(e => e.Qualifications)
                .HasMaxLength(200)
                .HasColumnName("qualifications");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
            entity.Property(e => e.Specialization)
                .HasMaxLength(200)
                .HasColumnName("specialization");
            entity.Property(e => e.TeacherCode)
                .HasMaxLength(50)
                .HasColumnName("teacher_code");

            entity.HasOne(d => d.Grades).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.GradesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teachers_Grades");

            entity.HasOne(d => d.applicationUser).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.applicationUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teachers_People");
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
