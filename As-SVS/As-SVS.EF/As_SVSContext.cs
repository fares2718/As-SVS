using System;
using System.Collections.Generic;
using As_SVS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace As_SVS.EF;

public partial class As_SVSContext : DbContext
{
    public As_SVSContext()
    {
    }

    public As_SVSContext(DbContextOptions<As_SVSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Annoucement> Annoucements { get; set; }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrolment> Enrolments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LiveAttendance> LiveAttendances { get; set; }

    public virtual DbSet<LiveSession> LiveSessions { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Person> People { get; set; }

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
        => optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-O1ENIR6;User ID=sa;Password=sa123456;
            Database=As-SVSDb;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;
            Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasIndex(e => e.Username, "UQ_Admins_Username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Person).WithMany(p => p.Admins)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admins_People");
        });

        modelBuilder.Entity<Annoucement>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Annoucement1).HasColumnName("annoucement");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Course).WithMany(p => p.Annoucements)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Annoucements_Courses");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Annoucements)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Annoucements_Teachers");
        });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(200)
                .HasColumnName("file_url");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedDue).HasColumnName("updated_due");

            entity.HasOne(d => d.Course).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignments_Courses");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignments_Teachers");
        });

        modelBuilder.Entity<AssignmentSubmission>(entity =>
        {
            entity.ToTable("Assignment_Submissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");
            entity.Property(e => e.Feedback)
                .HasMaxLength(200)
                .HasColumnName("feedback");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(200)
                .HasColumnName("file_url");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Assignment).WithMany(p => p.AssignmentSubmissions)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignment_Submissions_Assignments");

            entity.HasOne(d => d.Student).WithMany(p => p.AssignmentSubmissions)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignment_Submissions_Students");
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
                .HasNoKey()
                .ToTable("Enrolment");

            entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.EnrolmentDate).HasColumnName("enrolment_date");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrolment_Courses");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrolment_Students");

            entity.HasOne(d => d.Teacher).WithMany()
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrolment_Teachers");
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

        modelBuilder.Entity<LiveAttendance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LiveAttendance");

            entity.Property(e => e.JoinedAt).HasColumnName("joined_at");
            entity.Property(e => e.LeftAt).HasColumnName("left_at");
            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Session).WithMany()
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LiveAttendance_LiveSessions");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LiveAttendance_Students");
        });

        modelBuilder.Entity<LiveSession>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.MeetingUrl).HasColumnName("meeting_url");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Room).WithMany(p => p.LiveSessions)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LiveSessions_Rooms");

            entity.HasOne(d => d.Teacher).WithMany(p => p.LiveSessions)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LiveSessions_Teachers");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attachments)
                .HasMaxLength(200)
                .HasColumnName("attachments");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.EditedAt).HasColumnName("edited_at");
            entity.Property(e => e.MessageContent)
                .HasMaxLength(200)
                .HasColumnName("message_content");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Person).WithMany(p => p.Messages)
                .HasForeignKey(d => d.PersonId)
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

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasIndex(e => e.Email, "UQ_Pesron_Email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .HasColumnName("image_url");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .HasColumnName("password");
            entity.Property(e => e.Permission)
                  .HasConversion<int>()
                  .HasColumnName("permissions");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
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
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Average).HasColumnName("average");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.MotherName)
                .HasMaxLength(100)
                .HasColumnName("mother_name");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.StudentCode)
                .HasMaxLength(50)
                .HasColumnName("student_code");

            entity.HasOne(d => d.Grade).WithMany(p => p.Students)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Grades");

            entity.HasOne(d => d.Person).WithMany(p => p.Students)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_People");
        });

        modelBuilder.Entity<StudentLesson>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Student_Lesson");

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
                .HasNoKey()
                .ToTable("Student_Quiz_Attemp");

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
                .HasNoKey()
                .ToTable("Student_Room");

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
            entity.Property(e => e.NationalNumber)
                .HasMaxLength(20)
                .HasColumnName("national_number");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
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

            entity.HasOne(d => d.Person).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teachers_People");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
