using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Data.Migrations
{
    public partial class todoEntityChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireOn",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Todos");

            migrationBuilder.AddColumn<DateTime>(
                name: "AlertOn",
                table: "Todos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertOn",
                table: "Todos");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireOn",
                table: "Todos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
