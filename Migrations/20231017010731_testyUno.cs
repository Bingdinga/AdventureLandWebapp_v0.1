using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureLandWebapp.Migrations
{
    /// <inheritdoc />
    public partial class testyUno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INVENTORY_CATALOGUE_ENTRY");

            migrationBuilder.CreateTable(
                name: "SHOP_INVENTORY_ITEM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopID = table.Column<int>(type: "int", nullable: false),
                    Stocked_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sold_On = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHOP_INVENTORY_ITEM", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHOP_INVENTORY_ITEM");

            migrationBuilder.CreateTable(
                name: "INVENTORY_CATALOGUE_ENTRY",
                columns: table => new
                {
                    Inventory_catalogue_entryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restock_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_CATALOGUE_ENTRY", x => x.Inventory_catalogue_entryID);
                });
        }
    }
}
