using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueModas.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreatedAt", "ImagePath", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("14a13698-82f8-4dd8-9728-391e419fa1f8"), new DateTime(2021, 8, 16, 22, 56, 5, 365, DateTimeKind.Local).AddTicks(3748), "assets/images/image1.jpg", "Blusa de lã", 49.99m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(321) },
                    { new Guid("de9e7818-aaf9-48fa-b0b1-9581dc83a446"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(649), "assets/images/image2.jpg", "Jaqueta de couro", 159.99m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(653) },
                    { new Guid("e7507243-5e0a-4f03-819f-b4f241097156"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(656), "assets/images/image3.jpg", "Blusa moletom", 39.99m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(656) },
                    { new Guid("6f828370-7fce-4b54-af57-1e80508497f8"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(658), "assets/images/image4.jpg", "Gorro para catioro", 24.99m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(659) },
                    { new Guid("df079ab5-5f0e-4af9-9ee8-55b75a586066"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(661), "assets/images/image5.jpg", "Camiseta branca", 19.99m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(662) },
                    { new Guid("3131a6ac-9fc1-4f61-b3a6-8b2fa6e5615e"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(664), "assets/images/image6.jpg", "Calça jeans", 69.99m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(665) },
                    { new Guid("9f1c47b3-8961-4c44-8957-c02285490189"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(674), "assets/images/image7.jpg", "Vestido vermelho", 49.99m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(675) },
                    { new Guid("5b617d3d-f40d-4930-86e1-9810838cd1f6"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(678), "assets/images/image8.jpg", "Camisa", 54.99m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(678) },
                    { new Guid("5d1ec522-114c-4520-9fd2-23982f413341"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(680), "assets/images/image9.jpg", "Jaqueta jeans", 89.99m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(681) },
                    { new Guid("68d248ac-5cd3-42f3-9d40-d3488f85f871"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(683), "assets/images/image10.jpg", "Camiseta de manga longa", 25.00m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(684) },
                    { new Guid("ca2f253a-7d3d-4834-a900-d4d438243d59"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(686), "assets/images/image11.jpg", "Jaqueta de couro", 190.00m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(687) },
                    { new Guid("a2a4ec6a-ba84-44f9-b950-83c14a87cc59"), new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(688), "assets/images/image12.jpg", "Vestido floral", 59.99m, new DateTime(2021, 8, 16, 22, 56, 5, 366, DateTimeKind.Local).AddTicks(689) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
