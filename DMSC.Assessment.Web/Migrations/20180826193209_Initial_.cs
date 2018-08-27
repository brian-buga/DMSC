using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMSC.Assessment.Web.Migrations
{
    public partial class Initial_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Publish",
                table: "Articles",
                newName: "Active");

            migrationBuilder.AddColumn<DateTime>(
                name: "Published",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Published",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Articles",
                newName: "Publish");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Articles",
                nullable: true);
        }
    }
}
