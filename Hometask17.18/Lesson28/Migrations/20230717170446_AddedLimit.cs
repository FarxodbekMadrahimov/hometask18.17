using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson28.Migrations
{
    public partial class AddedLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Limit",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("05fedfbc-95c7-4981-a7dd-af8cfd54e95c"),
                column: "Limit",
                value: 85);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("6561e66a-29a5-47f2-a22b-ca47c8c38f24"),
                column: "Limit",
                value: 45);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Limit",
                table: "Groups");
        }
    }
}
