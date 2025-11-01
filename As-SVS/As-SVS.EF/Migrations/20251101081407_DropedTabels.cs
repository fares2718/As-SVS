using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsSVS.EF.Migrations
{
    /// <inheritdoc />
    public partial class DropedTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annoucements");

            migrationBuilder.DropTable(
                name: "Assignment_Submissions");

            migrationBuilder.DropTable(
                name: "Live_Attendance");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "LiveSessions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annoucements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    annoucement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    due_date = table.Column<DateOnly>(type: "date", nullable: false),
                    file_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                name: "LiveSessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time", nullable: true),
                    meeting_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time", nullable: false)
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
                name: "Assignment_Submissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignment_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    feedback = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    file_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                name: "Live_Attendance",
                columns: table => new
                {
                    session_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    joined_at = table.Column<TimeOnly>(type: "time", nullable: false),
                    left_at = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Live_Attendance", x => new { x.session_id, x.student_id });
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
                name: "IX_Live_Attendance_student_id",
                table: "Live_Attendance",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_LiveSessions_room_id",
                table: "LiveSessions",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_LiveSessions_teacher_id",
                table: "LiveSessions",
                column: "teacher_id");
        }
    }
}
