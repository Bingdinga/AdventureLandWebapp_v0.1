using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureLandWebapp.Migrations
{
    /// <inheritdoc />
    public partial class GreensUno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATTRACTION",
                columns: table => new
                {
                    AttractionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttractionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Open_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Close_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_Maintained = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height_Req_Inches = table.Column<int>(type: "int", nullable: false),
                    Age_Req = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTRACTION", x => x.AttractionID);
                });

            migrationBuilder.CreateTable(
                name: "EVENT",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueID = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Event_Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Event_Ended = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "INVENTORY_CATALOGUE_ENTRY",
                columns: table => new
                {
                    Inventory_catalogue_entryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Restock_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_CATALOGUE_ENTRY", x => x.Inventory_catalogue_entryID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATTRACTION");

            migrationBuilder.DropTable(
                name: "EVENT");

            migrationBuilder.DropTable(
                name: "INVENTORY_CATALOGUE_ENTRY");
        }
    }
}
