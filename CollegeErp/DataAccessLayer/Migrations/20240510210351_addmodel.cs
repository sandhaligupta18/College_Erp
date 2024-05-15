using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Friday",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "Monday",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "Thrusday",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "Tuesday",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "Wednesday",
                table: "TimeTables");

            migrationBuilder.RenameColumn(
                name: "Timmings",
                table: "TimeTables",
                newName: "StartLecture");

            migrationBuilder.RenameColumn(
                name: "Saturday",
                table: "TimeTables",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "Sno",
                table: "TimeTables",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Days",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndLecture",
                table: "TimeTables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TimeTables",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "EndLecture",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TimeTables");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "TimeTables",
                newName: "Saturday");

            migrationBuilder.RenameColumn(
                name: "StartLecture",
                table: "TimeTables",
                newName: "Timmings");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TimeTables",
                newName: "Sno");

            migrationBuilder.AddColumn<string>(
                name: "Friday",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Monday",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thrusday",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tuesday",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Wednesday",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
