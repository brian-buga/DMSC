using Microsoft.EntityFrameworkCore.Migrations;

namespace DMSC.Assessment.Web.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifyAt",
                table: "Users",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifyAt",
                table: "Likes",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifyAt",
                table: "Articles",
                newName: "ModifiedAt");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Likes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Users",
                newName: "ModifyAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Likes",
                newName: "ModifyAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Articles",
                newName: "ModifyAt");
        }
    }
}
