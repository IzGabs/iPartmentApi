using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class brabo7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_RealEstateTypes_TypeId",
                table: "RealEstates");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_RealEstateTypes_TypeId",
                table: "RealEstates",
                column: "TypeId",
                principalTable: "RealEstateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_RealEstateTypes_TypeId",
                table: "RealEstates");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_RealEstateTypes_TypeId",
                table: "RealEstates",
                column: "TypeId",
                principalTable: "RealEstateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
