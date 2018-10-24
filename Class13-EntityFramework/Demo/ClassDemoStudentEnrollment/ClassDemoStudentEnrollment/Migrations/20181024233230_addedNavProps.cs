using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassDemoStudentEnrollment.Migrations
{
    public partial class addedNavProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_CourseID",
                table: "Transcripts",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_StudentID",
                table: "Transcripts",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_StudentID",
                table: "CourseEnrollments",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Courses_CourseID",
                table: "CourseEnrollments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Students_StudentID",
                table: "CourseEnrollments",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transcripts_Courses_CourseID",
                table: "Transcripts",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transcripts_Students_StudentID",
                table: "Transcripts",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Courses_CourseID",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Students_StudentID",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Transcripts_Courses_CourseID",
                table: "Transcripts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transcripts_Students_StudentID",
                table: "Transcripts");

            migrationBuilder.DropIndex(
                name: "IX_Transcripts_CourseID",
                table: "Transcripts");

            migrationBuilder.DropIndex(
                name: "IX_Transcripts_StudentID",
                table: "Transcripts");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrollments_StudentID",
                table: "CourseEnrollments");
        }
    }
}
