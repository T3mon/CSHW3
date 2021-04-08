using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class keystoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HiringHistories_Achievements_AchievementsId",
                table: "HiringHistories");

            migrationBuilder.DropIndex(
                name: "IX_HiringHistories_AchievementsId",
                table: "HiringHistories");

            migrationBuilder.DropColumn(
                name: "AchievementsId",
                table: "HiringHistories");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeId",
                table: "HiringHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HiringHistorieId",
                table: "Achievements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_HiringHistorieId",
                table: "Achievements",
                column: "HiringHistorieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_HiringHistories_HiringHistorieId",
                table: "Achievements",
                column: "HiringHistorieId",
                principalTable: "HiringHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_HiringHistories_HiringHistorieId",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_HiringHistorieId",
                table: "Achievements");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeId",
                table: "HiringHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AchievementsId",
                table: "HiringHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HiringHistorieId",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_HiringHistories_AchievementsId",
                table: "HiringHistories",
                column: "AchievementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_HiringHistories_Achievements_AchievementsId",
                table: "HiringHistories",
                column: "AchievementsId",
                principalTable: "Achievements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
