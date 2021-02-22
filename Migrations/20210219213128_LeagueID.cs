using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class LeagueID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_League_LeagueID",
                table: "Player");

            migrationBuilder.AlterColumn<int>(
                name: "LeagueID",
                table: "Player",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_League_LeagueID",
                table: "Player",
                column: "LeagueID",
                principalTable: "League",
                principalColumn: "LeagueID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_League_LeagueID",
                table: "Player");

            migrationBuilder.AlterColumn<int>(
                name: "LeagueID",
                table: "Player",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Player_League_LeagueID",
                table: "Player",
                column: "LeagueID",
                principalTable: "League",
                principalColumn: "LeagueID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
