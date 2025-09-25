using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsSVS.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_progress_limited = table.Column<bool>(type: "bit", nullable: false),
                    course_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    grade_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grade_level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    number = table.Column<decimal>(type: "numeric(12,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    permissions = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grade_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    updated_at = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.id);
                    table.ForeignKey(
                        name: "FK_Module_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    person_id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    salary = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.id);
                    table.ForeignKey(
                        name: "FK_Admins_People",
                        column: x => x.person_id,
                        principalTable: "People",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    person_id = table.Column<int>(type: "int", nullable: false),
                    grade_id = table.Column<int>(type: "int", nullable: false),
                    mother_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    average = table.Column<double>(type: "float", nullable: true),
                    student_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Grades",
                        column: x => x.grade_id,
                        principalTable: "Grades",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Students_People",
                        column: x => x.person_id,
                        principalTable: "People",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    person_id = table.Column<int>(type: "int", nullable: false),
                    specialization = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    national_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    teacher_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    qualifications = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    grades_id = table.Column<int>(type: "int", nullable: false),
                    feedbacks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    salary = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teachers_Grades",
                        column: x => x.grades_id,
                        principalTable: "Grades",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Teachers_People",
                        column: x => x.person_id,
                        principalTable: "People",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_id = table.Column<int>(type: "int", nullable: false),
                    person_id = table.Column<int>(type: "int", nullable: false),
                    message_content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    attachments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    edited_at = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Messages_People",
                        column: x => x.person_id,
                        principalTable: "People",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Messages_Rooms",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Student_Room",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    room_id = table.Column<int>(type: "int", nullable: false),
                    join_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Student_Room_Rooms",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    video_url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    lesson_details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lesson_Module",
                        column: x => x.module_id,
                        principalTable: "Module",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Quizes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    course_order = table.Column<int>(type: "int", nullable: false),
                    min_pass_score = table.Column<double>(type: "float", nullable: false),
                    is_pass_requiered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Quizes_Module",
                        column: x => x.module_id,
                        principalTable: "Module",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    grade_id = table.Column<int>(type: "int", nullable: false),
                    certificate_number = table.Column<int>(type: "int", nullable: false),
                    issued_at = table.Column<DateOnly>(type: "date", nullable: false),
                    file_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.id);
                    table.ForeignKey(
                        name: "FK_Certificates_Grades",
                        column: x => x.grade_id,
                        principalTable: "Grades",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Certificates_Students",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Annoucements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    annoucement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annoucements", x => x.id);
                    table.ForeignKey(
                        name: "FK_Annoucements_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Annoucements_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    file_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    due_date = table.Column<DateOnly>(type: "date", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    updated_due = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Assignments_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Enrolment",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    enrolment_date = table.Column<DateOnly>(type: "date", nullable: true),
                    completion_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Enrolment_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Enrolment_Students",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Enrolment_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "LiveSessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    meeting_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveSessions", x => x.id);
                    table.ForeignKey(
                        name: "FK_LiveSessions_Rooms",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_LiveSessions_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Student_Lesson",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    lesson_id = table.Column<int>(type: "int", nullable: false),
                    is_completed = table.Column<bool>(type: "bit", nullable: false),
                    completion_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Student_Lesson_Lesson",
                        column: x => x.lesson_id,
                        principalTable: "Lesson",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Student_Lesson_Students",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Quiz_Questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quiz_id = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz_Questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Quiz_Questions_Quizes",
                        column: x => x.quiz_id,
                        principalTable: "Quizes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Student_Quiz_Attemp",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    quiz_id = table.Column<int>(type: "int", nullable: false),
                    attemp_date = table.Column<DateOnly>(type: "date", nullable: true),
                    score_achived = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Student_Quiz_Attemp_Quizes",
                        column: x => x.quiz_id,
                        principalTable: "Quizes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Student_Quiz_Attemp_Students",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Assignment_Submissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignment_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    file_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    feedback = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment_Submissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Assignment_Submissions_Assignments",
                        column: x => x.assignment_id,
                        principalTable: "Assignments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Assignment_Submissions_Students",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "LiveAttendance",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    session_id = table.Column<int>(type: "int", nullable: false),
                    joined_at = table.Column<TimeOnly>(type: "time", nullable: false),
                    left_at = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_LiveAttendance_LiveSessions",
                        column: x => x.session_id,
                        principalTable: "LiveSessions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_LiveAttendance_Students",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Question_Options",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    option_text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    number = table.Column<decimal>(type: "numeric(4,0)", nullable: false),
                    is_correct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question_Options", x => x.id);
                    table.ForeignKey(
                        name: "FK_Question_Options_Quiz_Questions",
                        column: x => x.question_id,
                        principalTable: "Quiz_Questions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_person_id",
                table: "Admins",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "UQ_Admins_Username",
                table: "Admins",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_course_id",
                table: "Annoucements",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_teacher_id",
                table: "Annoucements",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_Submissions_assignment_id",
                table: "Assignment_Submissions",
                column: "assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_Submissions_student_id",
                table: "Assignment_Submissions",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_course_id",
                table: "Assignments",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_teacher_id",
                table: "Assignments",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_grade_id",
                table: "Certificates",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_student_id",
                table: "Certificates",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_course_id",
                table: "Enrolment",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_student_id",
                table: "Enrolment",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_teacher_id",
                table: "Enrolment",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_module_id",
                table: "Lesson",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "UQ_Lesson_Number",
                table: "Lesson",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Lesson_Order",
                table: "Lesson",
                column: "course_order",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiveAttendance_session_id",
                table: "LiveAttendance",
                column: "session_id");

            migrationBuilder.CreateIndex(
                name: "IX_LiveAttendance_student_id",
                table: "LiveAttendance",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_LiveSessions_room_id",
                table: "LiveSessions",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_LiveSessions_teacher_id",
                table: "LiveSessions",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_person_id",
                table: "Messages",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_room_id",
                table: "Messages",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Module_course_id",
                table: "Module",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "UQ_Pesron_Email",
                table: "People",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_Options_question_id",
                table: "Question_Options",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_Questions_quiz_id",
                table: "Quiz_Questions",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_module_id",
                table: "Quizes",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Lesson_lesson_id",
                table: "Student_Lesson",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Lesson_student_id",
                table: "Student_Lesson",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Quiz_Attemp_quiz_id",
                table: "Student_Quiz_Attemp",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Quiz_Attemp_student_id",
                table: "Student_Quiz_Attemp",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Room_room_id",
                table: "Student_Room",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_grade_id",
                table: "Students",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_person_id",
                table: "Students",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_grades_id",
                table: "Teachers",
                column: "grades_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_person_id",
                table: "Teachers",
                column: "person_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Annoucements");

            migrationBuilder.DropTable(
                name: "Assignment_Submissions");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Enrolment");

            migrationBuilder.DropTable(
                name: "LiveAttendance");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Question_Options");

            migrationBuilder.DropTable(
                name: "Student_Lesson");

            migrationBuilder.DropTable(
                name: "Student_Quiz_Attemp");

            migrationBuilder.DropTable(
                name: "Student_Room");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "LiveSessions");

            migrationBuilder.DropTable(
                name: "Quiz_Questions");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Quizes");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
