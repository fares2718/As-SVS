using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsSVS.EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKeysAndInitials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_person_id",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_person_id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Student_Room_room_id",
                table: "Student_Room");

            migrationBuilder.DropIndex(
                name: "IX_Student_Quiz_Attemp_quiz_id",
                table: "Student_Quiz_Attemp");

            migrationBuilder.DropIndex(
                name: "IX_Enrolment_student_id",
                table: "Enrolment");

            migrationBuilder.DropIndex(
                name: "IX_Admins_person_id",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Student_Lesson_lesson_id",
                table: "Student_Lesson");

            migrationBuilder.DropIndex(
                name: "IX_LiveAttendance_session_id",
                table: "LiveAttendance");

            migrationBuilder.RenameTable(
                name: "Student_Lesson",
                newName: "Student_Lessons");

            migrationBuilder.RenameTable(
                name: "LiveAttendance",
                newName: "Live_Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Lesson_student_id",
                table: "Student_Lessons",
                newName: "IX_Student_Lessons_student_id");

            migrationBuilder.RenameIndex(
                name: "IX_LiveAttendance_student_id",
                table: "Live_Attendance",
                newName: "IX_Live_Attendance_student_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Room",
                table: "Student_Room",
                columns: new[] { "room_id", "student_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Quiz_Attemp",
                table: "Student_Quiz_Attemp",
                columns: new[] { "quiz_id", "student_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrolment",
                table: "Enrolment",
                columns: new[] { "student_id", "course_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Lessons",
                table: "Student_Lessons",
                columns: new[] { "lesson_id", "student_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Live_Attendance",
                table: "Live_Attendance",
                columns: new[] { "session_id", "student_id" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_person_id",
                table: "Teachers",
                column: "person_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_person_id",
                table: "Students",
                column: "person_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_person_id",
                table: "Admins",
                column: "person_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_person_id",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_person_id",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Room",
                table: "Student_Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Quiz_Attemp",
                table: "Student_Quiz_Attemp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrolment",
                table: "Enrolment");

            migrationBuilder.DropIndex(
                name: "IX_Admins_person_id",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Lessons",
                table: "Student_Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Live_Attendance",
                table: "Live_Attendance");

            migrationBuilder.RenameTable(
                name: "Student_Lessons",
                newName: "Student_Lesson");

            migrationBuilder.RenameTable(
                name: "Live_Attendance",
                newName: "LiveAttendance");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Lessons_student_id",
                table: "Student_Lesson",
                newName: "IX_Student_Lesson_student_id");

            migrationBuilder.RenameIndex(
                name: "IX_Live_Attendance_student_id",
                table: "LiveAttendance",
                newName: "IX_LiveAttendance_student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_person_id",
                table: "Teachers",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_person_id",
                table: "Students",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Room_room_id",
                table: "Student_Room",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Quiz_Attemp_quiz_id",
                table: "Student_Quiz_Attemp",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_student_id",
                table: "Enrolment",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_person_id",
                table: "Admins",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Lesson_lesson_id",
                table: "Student_Lesson",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_LiveAttendance_session_id",
                table: "LiveAttendance",
                column: "session_id");
        }
    }
}
