using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureLandWebapp.Migrations
{
    /// <inheritdoc />
    public partial class testy6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SHOP_ITEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Restock_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHOP_ITEM", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHOP_ITEM");
        }
    }
}
