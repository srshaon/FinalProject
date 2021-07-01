using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstTry.Migrations
{
    public partial class ClassSchedule2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedule_Courses_CourseID",
                table: "ClassSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule");

            migrationBuilder.RenameTable(
                name: "ClassSchedule",
                newName: "classSchedules");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSchedule_CourseID",
                table: "classSchedules",
                newName: "IX_classSchedules_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classSchedules",
                table: "classSchedules",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_classSchedules_Courses_CourseID",
                table: "classSchedules",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classSchedules_Courses_CourseID",
                table: "classSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_classSchedules",
                table: "classSchedules");

            migrationBuilder.RenameTable(
                name: "classSchedules",
                newName: "ClassSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_classSchedules_CourseID",
                table: "ClassSchedule",
                newName: "IX_ClassSchedule_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedule_Courses_CourseID",
                table: "ClassSchedule",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
