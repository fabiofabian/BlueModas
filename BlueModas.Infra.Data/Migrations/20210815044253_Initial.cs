using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueModas.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new Guid("2debc054-b480-470d-a1d6-07106a705c61"), new DateTime(2021, 8, 15, 1, 42, 53, 654, DateTimeKind.Local).AddTicks(5682), "Camiseta de algodão macio", "Camiseta Branca", new DateTime(2021, 8, 15, 1, 42, 53, 655, DateTimeKind.Local).AddTicks(2816) });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new Guid("829df3f6-2641-421e-a0de-e9f757337bc6"), new DateTime(2021, 8, 15, 1, 42, 53, 655, DateTimeKind.Local).AddTicks(3143), "Blusa de algodão macio", "Blusa Azul", new DateTime(2021, 8, 15, 1, 42, 53, 655, DateTimeKind.Local).AddTicks(3147) });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "CreatedAt", "Location", "ProductId", "UpdatedAt" },
                values: new object[] { new Guid("940b1a36-0fa2-40a6-b425-bd25144c82c2"), new DateTime(2021, 8, 15, 1, 42, 53, 657, DateTimeKind.Local).AddTicks(1502), "/images/products/image1.jpg", new Guid("2debc054-b480-470d-a1d6-07106a705c61"), new DateTime(2021, 8, 15, 1, 42, 53, 657, DateTimeKind.Local).AddTicks(1511) });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "CreatedAt", "Location", "ProductId", "UpdatedAt" },
                values: new object[] { new Guid("5398c5c5-4de2-4c15-8c27-4bfdf65fcd57"), new DateTime(2021, 8, 15, 1, 42, 53, 657, DateTimeKind.Local).AddTicks(1522), "/images/products/image1.jpg", new Guid("829df3f6-2641-421e-a0de-e9f757337bc6"), new DateTime(2021, 8, 15, 1, 42, 53, 657, DateTimeKind.Local).AddTicks(1523) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
