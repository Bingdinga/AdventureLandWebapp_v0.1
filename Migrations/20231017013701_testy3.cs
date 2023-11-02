using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureLandWebapp.Migrations
{
    /// <inheritdoc />
    public partial class testy3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATTRACTION_EMPLOYEE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    AttractionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTRACTION_EMPLOYEE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EVENT_WORK_REC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Work_Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Work_Completed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_WORK_REC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MAINTENENCE_PERSONNEL_REC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maint_RecID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    work_started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    work_ended = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAINTENENCE_PERSONNEL_REC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MAINTENENCE_REC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttractionID = table.Column<int>(type: "int", nullable: false),
                    Main_Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Main_Ended = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAINTENENCE_REC", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATTRACTION_EMPLOYEE");

            migrationBuilder.DropTable(
                name: "EVENT_WORK_REC");

            migrationBuilder.DropTable(
                name: "MAINTENENCE_PERSONNEL_REC");

            migrationBuilder.DropTable(
                name: "MAINTENENCE_REC");
        }
    }
}
