using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EsperoQueUltima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    Longitude = table.Column<double>(type: "double", nullable: false),
                    ExtraInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AnnouncementRentMonetary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    montlyValue = table.Column<float>(type: "float", nullable: false),
                    IPTU = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementRentMonetary", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AnnouncementSellMonetary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    value = table.Column<float>(type: "float", nullable: false),
                    IPTU = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementSellMonetary", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CondominiumMonetary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    montlyValue = table.Column<float>(type: "float", nullable: false),
                    fireInsurence = table.Column<float>(type: "float", nullable: true),
                    serviceCharge = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondominiumMonetary", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RealEstateTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    PushToken = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Condominiums",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    Gym = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ValuesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominiums", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Condominiums_Addresses_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Condominiums_CondominiumMonetary_ValuesID",
                        column: x => x.ValuesID,
                        principalTable: "CondominiumMonetary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AgentDocumentsImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pathToFile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentDocumentsImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AgentDocumentsImages_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pathToFile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserImages_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    squareMeters = table.Column<int>(type: "int", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    RoomWithBathroom = table.Column<int>(type: "int", nullable: false),
                    Furnished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AllowPets = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Garage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdressID = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    CurrentResidentID = table.Column<int>(type: "int", nullable: true),
                    CondominiumID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealEstates_Addresses_AdressID",
                        column: x => x.AdressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstates_Condominiums_CondominiumID",
                        column: x => x.CondominiumID,
                        principalTable: "Condominiums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstates_RealEstateTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RealEstateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstates_Users_CurrentResidentID",
                        column: x => x.CurrentResidentID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AgentDocuments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    CRECIID = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imageID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AgentDocuments_AgentDocumentsImages_imageID",
                        column: x => x.imageID,
                        principalTable: "AgentDocumentsImages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgentDocuments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdvertiserID = table.Column<int>(type: "int", nullable: true),
                    RealEstateID = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<int>(type: "int", nullable: false),
                    AnnouncementSellId = table.Column<int>(type: "int", nullable: true),
                    AnnouncementRentId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    immediatelyAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Announcements_AnnouncementRentMonetary_AnnouncementRentId",
                        column: x => x.AnnouncementRentId,
                        principalTable: "AnnouncementRentMonetary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Announcements_AnnouncementSellMonetary_AnnouncementSellId",
                        column: x => x.AnnouncementSellId,
                        principalTable: "AnnouncementSellMonetary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Announcements_RealEstates_RealEstateID",
                        column: x => x.RealEstateID,
                        principalTable: "RealEstates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Announcements_Users_AdvertiserID",
                        column: x => x.AdvertiserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RealEstateImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RealEstateID = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pathToFile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealEstateImages_RealEstates_RealEstateID",
                        column: x => x.RealEstateID,
                        principalTable: "RealEstates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScheduledVisits",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    announcementID = table.Column<int>(type: "int", nullable: true),
                    visitorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledVisits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScheduledVisits_Announcements_announcementID",
                        column: x => x.announcementID,
                        principalTable: "Announcements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledVisits_Users_visitorID",
                        column: x => x.visitorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "RealEstateTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 0, "", "APARTMENT" },
                    { 1, "", "HOUSE" },
                    { 2, "", "KITNET" },
                    { 3, "", "STUDIO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentDocuments_imageID",
                table: "AgentDocuments",
                column: "imageID");

            migrationBuilder.CreateIndex(
                name: "IX_AgentDocuments_UserID",
                table: "AgentDocuments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AgentDocumentsImages_UserID",
                table: "AgentDocumentsImages",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AdvertiserID",
                table: "Announcements",
                column: "AdvertiserID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AnnouncementRentId",
                table: "Announcements",
                column: "AnnouncementRentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AnnouncementSellId",
                table: "Announcements",
                column: "AnnouncementSellId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_RealEstateID",
                table: "Announcements",
                column: "RealEstateID");

            migrationBuilder.CreateIndex(
                name: "IX_Condominiums_LocationID",
                table: "Condominiums",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Condominiums_ValuesID",
                table: "Condominiums",
                column: "ValuesID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateImages_RealEstateID",
                table: "RealEstateImages",
                column: "RealEstateID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_AdressID",
                table: "RealEstates",
                column: "AdressID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_CondominiumID",
                table: "RealEstates",
                column: "CondominiumID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_CurrentResidentID",
                table: "RealEstates",
                column: "CurrentResidentID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_TypeId",
                table: "RealEstates",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledVisits_announcementID",
                table: "ScheduledVisits",
                column: "announcementID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledVisits_visitorID",
                table: "ScheduledVisits",
                column: "visitorID");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserID",
                table: "UserImages",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentDocuments");

            migrationBuilder.DropTable(
                name: "RealEstateImages");

            migrationBuilder.DropTable(
                name: "ScheduledVisits");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "AgentDocumentsImages");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "AnnouncementRentMonetary");

            migrationBuilder.DropTable(
                name: "AnnouncementSellMonetary");

            migrationBuilder.DropTable(
                name: "RealEstates");

            migrationBuilder.DropTable(
                name: "Condominiums");

            migrationBuilder.DropTable(
                name: "RealEstateTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CondominiumMonetary");
        }
    }
}
