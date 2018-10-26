using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolEnrollment.Migrations
{
    public partial class experiement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Technology = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 15, nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollments",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollments", x => new { x.CourseID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transcript",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    Grade = table.Column<string>(nullable: true),
                    Pass = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcript", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transcript_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transcript_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Name", "Price", "Technology" },
                values: new object[,]
                {
                    { 1, "ethics", 350.99m, 0 },
                    { 2, "Advanced Python", 300.99m, 2 },
                    { 43, "c sharp", 250.99m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "ID", "Age", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 36, "Jack", "Shepard" },
                    { 2, 34, "Kate", "Austin" },
                    { 3, 40, "Kanye", "West" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_StudentID",
                table: "CourseEnrollments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Transcript_CourseID",
                table: "Transcript",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Transcript_StudentID",
                table: "Transcript",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEnrollments");

            migrationBuilder.DropTable(
                name: "Transcript");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
