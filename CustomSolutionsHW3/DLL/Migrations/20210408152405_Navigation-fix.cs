using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Navigationfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_HiringHistories_HiringHistoriesId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_HiringHistoriesId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_HiringHistorieId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "HiringHistoriesId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "HiringHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HiringHistories_EmployeeId",
                table: "HiringHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_HiringHistorieId",
                table: "Achievements",
                column: "HiringHistorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_HiringHistories_Employees_EmployeeId",
                table: "HiringHistories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HiringHistories_Employees_EmployeeId",
                table: "HiringHistories");

            migrationBuilder.DropIndex(
                name: "IX_HiringHistories_EmployeeId",
                table: "HiringHistories");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_HiringHistorieId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "HiringHistories");

            migrationBuilder.AddColumn<int>(
                name: "HiringHistoriesId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HiringHistoriesId",
                table: "Employees",
                column: "HiringHistoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_HiringHistorieId",
                table: "Achievements",
                column: "HiringHistorieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_HiringHistories_HiringHistoriesId",
                table: "Employees",
                column: "HiringHistoriesId",
                principalTable: "HiringHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
