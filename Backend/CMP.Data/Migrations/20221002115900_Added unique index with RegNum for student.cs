using Microsoft.EntityFrameworkCore.Migrations;

namespace CMP.Data.Migrations
{
    public partial class AddeduniqueindexwithRegNumforstudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegNum",
                table: "Student",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Student_RegNum",
                table: "Student",
                column: "RegNum",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Student_RegNum",
                table: "Student");

            migrationBuilder.AlterColumn<string>(
                name: "RegNum",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
