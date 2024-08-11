using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeShop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeShopName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoffeeShopDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeShop", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CoffeeShop",
                columns: new[] { "Id", "CoffeeShopDescription", "CoffeeShopName", "CreationDateTime", "IsActive", "IsOpen" },
                values: new object[,]
                {
                    { new Guid("39d2b4f1-060e-45f8-b0cf-de4406b17846"), "Great and Lavish Place", "Star BUcks", new DateTime(2024, 8, 4, 21, 49, 35, 984, DateTimeKind.Local).AddTicks(6429), false, true },
                    { new Guid("6afd9403-249f-43db-9a0d-2007e1192b2f"), "The Great Coffee shop", "Barista", new DateTime(2024, 8, 4, 21, 49, 35, 984, DateTimeKind.Local).AddTicks(6474), false, true },
                    { new Guid("727691db-d90b-4fe0-afac-93674a8d474d"), "The US Brand Coffee shop", "The Filter Coffee", new DateTime(2024, 8, 4, 21, 49, 35, 984, DateTimeKind.Local).AddTicks(6477), false, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeShop");
        }
    }
}
