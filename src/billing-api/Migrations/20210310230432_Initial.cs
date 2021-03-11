using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "ImgUrl", "LastName" },
                values: new object[,]
                {
                    { 1, "t.start@bloxxon.co", "Tony", "https://i.imgflip.com/1bepoi.jpg", "Stark" },
                    { 2, "p.parker@bloxxon.co", "Peter", "https://media.tenor.com/images/980f9c417ca728c305659728764998c1/tenor.gif", "Parker" },
                    { 3, "b.banner@bloxxon.co", "Bruce", "https://img1.looper.com/img/gallery/will-bruce-banner-be-in-the-disney-she-hulk-series/intro-1569264697.jpg", "Banner" },
                    { 4, "robert.jabadiah.ph.freeman@boondocxxx.com", "Robert", "https://thesource.com/wp-content/uploads/2019/06/Check-Out-Robert-Freemans-Design-From-The-Boondocks-Reboot.jpg", "Freeman" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "CustomerId", "DeadLine" },
                values: new object[] { 1, 50000, 2, new DateTime(2021, 3, 25, 23, 4, 31, 811, DateTimeKind.Utc).AddTicks(4669) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
