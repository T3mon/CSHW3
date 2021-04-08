using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class foreignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "EmployeId",
                table: "HiringHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HiringHistorieId",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "HiringHistories");

            migrationBuilder.DropColumn(
                name: "HiringHistorieId",
                table: "Achievements");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "SecondName");
        }
    }
}
