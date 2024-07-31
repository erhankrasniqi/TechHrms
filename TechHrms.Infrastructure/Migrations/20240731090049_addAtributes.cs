using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechHrms.Infrastructure.Migrations
{
    public partial class addAtributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkExperience",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkExperience",
                table: "Employees");
        }
    }
}
