using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class LeaguePlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LeagueID",
                table: "Player",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Player_LeagueID",
                table: "Player",
                column: "LeagueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_League_LeagueID",
                table: "Player",
                column: "LeagueID",
                principalTable: "League",
                principalColumn: "LeagueID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_League_LeagueID",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_LeagueID",
                table: "Player");

            migrationBuilder.AlterColumn<int>(
                name: "LeagueID",
                table: "Player",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
