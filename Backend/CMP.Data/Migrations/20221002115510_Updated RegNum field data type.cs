using Microsoft.EntityFrameworkCore.Migrations;

namespace CMP.Data.Migrations
{
    public partial class UpdatedRegNumfielddatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegNum",
                table: "Student",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RegNum",
                table: "Student",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
