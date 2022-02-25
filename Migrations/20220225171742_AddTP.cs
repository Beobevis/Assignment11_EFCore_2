using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntitySample.Migrations
{
    public partial class AddTP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateTime", "Creator", "ModifiedTime", "Modifier", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Food" },
                    { 2, null, null, null, null, "Cosmetic" },
                    { 3, null, null, null, null, "Drinks" },
                    { 4, null, null, null, null, "Fashion" },
                    { 5, null, null, null, null, "Technologies" },
                    { 6, null, null, null, null, "Funiture" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreateTime", "Creator", "Manufacturer", "ModifiedTime", "Modifier", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, null, "Hai Ha", null, null, "Candy" },
                    { 2, 2, null, null, "Yves", null, null, "Lipstick" },
                    { 3, 3, null, null, "CocaCola", null, null, "Pepsi" },
                    { 4, 3, null, null, "Pepsi", null, null, "Sting" },
                    { 5, 4, null, null, "DG", null, null, "Jeans" },
                    { 6, 5, null, null, "Apple", null, null, "Iphone" },
                    { 7, 6, null, null, "Hoa Phat", null, null, "Chair" },
                    { 8, 6, null, null, "Hoa Phat", null, null, "Desk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
