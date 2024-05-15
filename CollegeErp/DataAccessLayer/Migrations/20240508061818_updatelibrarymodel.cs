using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatelibrarymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryData",
                table: "LibraryData");

            migrationBuilder.AlterColumn<string>(
                name: "EnrollNo",
                table: "LibraryData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "LibraryData",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryData",
                table: "LibraryData",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryData",
                table: "LibraryData");

            migrationBuilder.DropColumn(
                name: "id",
                table: "LibraryData");

            migrationBuilder.AlterColumn<string>(
                name: "EnrollNo",
                table: "LibraryData",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryData",
                table: "LibraryData",
                column: "EnrollNo");
        }
    }
}
