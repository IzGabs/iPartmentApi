using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class aMaisBraba23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AnnouncementRentMonetary_AnnouncementRentId",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AnnouncementSellMonetary_AnnouncementSellId",
                table: "Announcements");

            migrationBuilder.AlterColumn<int>(
                name: "AnnouncementSellId",
                table: "Announcements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnnouncementRentId",
                table: "Announcements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AnnouncementRentMonetary_AnnouncementRentId",
                table: "Announcements",
                column: "AnnouncementRentId",
                principalTable: "AnnouncementRentMonetary",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AnnouncementSellMonetary_AnnouncementSellId",
                table: "Announcements",
                column: "AnnouncementSellId",
                principalTable: "AnnouncementSellMonetary",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AnnouncementRentMonetary_AnnouncementRentId",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AnnouncementSellMonetary_AnnouncementSellId",
                table: "Announcements");

            migrationBuilder.AlterColumn<int>(
                name: "AnnouncementSellId",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnnouncementRentId",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AnnouncementRentMonetary_AnnouncementRentId",
                table: "Announcements",
                column: "AnnouncementRentId",
                principalTable: "AnnouncementRentMonetary",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AnnouncementSellMonetary_AnnouncementSellId",
                table: "Announcements",
                column: "AnnouncementSellId",
                principalTable: "AnnouncementSellMonetary",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
