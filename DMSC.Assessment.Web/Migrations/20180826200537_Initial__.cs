using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMSC.Assessment.Web.Migrations
{
    public partial class Initial__ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Articles",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Articles",
                newName: "ModifiedBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Likes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Likes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
