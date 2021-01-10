using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatShowing_Showing_ShowingID",
                table: "SeatShowing");

            migrationBuilder.DropIndex(
                name: "IX_SeatShowing_ShowingID",
                table: "SeatShowing");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SeatShowing_ShowingID",
                table: "SeatShowing",
                column: "ShowingID");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatShowing_Showing_ShowingID",
                table: "SeatShowing",
                column: "ShowingID",
                principalTable: "Showing",
                principalColumn: "ShowingID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
