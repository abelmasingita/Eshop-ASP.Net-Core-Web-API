using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eshopWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    paymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taxPrice = table.Column<double>(type: "float", nullable: false),
                    shippingPrice = table.Column<double>(type: "float", nullable: false),
                    totalPrice = table.Column<double>(type: "float", nullable: false),
                    isPaid = table.Column<bool>(type: "bit", nullable: false),
                    isDelivered = table.Column<bool>(type: "bit", nullable: false),
                    paidAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deliveredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NumReviews = table.Column<int>(type: "int", nullable: false),
                    CountInStock = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "1", "Abel", "Masingita" },
                    { "2", "Hlongwani", "Masingita" },
                    { "3", "Masingita", "Masingita" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "UserId", "deliveredAt", "isDelivered", "isPaid", "paidAt", "paymentMethod", "paymentResult", "shippingPrice", "taxPrice", "totalPrice" },
                values: new object[,]
                {
                    { "1", "1", new DateTime(2023, 2, 24, 3, 9, 25, 101, DateTimeKind.Local).AddTicks(4832), false, true, new DateTime(2023, 2, 24, 3, 9, 25, 101, DateTimeKind.Local).AddTicks(4847), "PayPal", "Success", 100.0, 100.0, 100.0 },
                    { "2", "2", new DateTime(2023, 2, 24, 3, 9, 25, 101, DateTimeKind.Local).AddTicks(4849), false, true, new DateTime(2023, 2, 24, 3, 9, 25, 101, DateTimeKind.Local).AddTicks(4850), "PayPal", "Success", 100.0, 100.0, 100.0 },
                    { "3", "3", new DateTime(2023, 2, 24, 3, 9, 25, 101, DateTimeKind.Local).AddTicks(4851), false, true, new DateTime(2023, 2, 24, 3, 9, 25, 101, DateTimeKind.Local).AddTicks(4851), "PayPal", "Success", 100.0, 100.0, 100.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "CountInStock", "Description", "Image", "Name", "NumReviews", "Price", "Rating", "UserId" },
                values: new object[,]
                {
                    { "1", "Nike", "Men", 5, "Converse", "", "All Star", 4, 100.0, 5.0, "1" },
                    { "2", "Nike", "Men", 5, "Converse", "", "All Star", 4, 100.0, 5.0, "2" },
                    { "3", "Nike", "Men", 5, "Converse", "", "All Star", 4, 100.0, 5.0, "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
