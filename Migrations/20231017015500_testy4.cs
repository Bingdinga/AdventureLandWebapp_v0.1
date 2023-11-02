using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureLandWebapp.Migrations
{
    /// <inheritdoc />
    public partial class testy4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUTH_CODES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auth_Code = table.Column<int>(type: "int", nullable: false),
                    Auth_Desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTH_CODES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GUEST",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone_Number = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUEST", x => x.GuestID);
                });

            migrationBuilder.CreateTable(
                name: "GUEST_REC",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestID = table.Column<int>(type: "int", nullable: false),
                    TicketID = table.Column<int>(type: "int", nullable: false),
                    Arrived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUEST_REC", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PERSONNEL_WORK_REC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    VenueID = table.Column<int>(type: "int", nullable: false),
                    work_started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    work_ended = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONNEL_WORK_REC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_CODES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Code = table.Column<int>(type: "int", nullable: false),
                    Role_Desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_CODES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TICKET",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purchase_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ticket_Type = table.Column<int>(type: "int", nullable: false),
                    GuestID = table.Column<int>(type: "int", nullable: false),
                    Valid_Through = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TICKET", x => x.TicketID);
                });

            migrationBuilder.CreateTable(
                name: "TICKET_TYPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticket_Code = table.Column<int>(type: "int", nullable: false),
                    Ticket_Type_Desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TICKET_TYPES", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUTH_CODES");

            migrationBuilder.DropTable(
                name: "GUEST");

            migrationBuilder.DropTable(
                name: "GUEST_REC");

            migrationBuilder.DropTable(
                name: "PERSONNEL_WORK_REC");

            migrationBuilder.DropTable(
                name: "ROLE_CODES");

            migrationBuilder.DropTable(
                name: "TICKET");

            migrationBuilder.DropTable(
                name: "TICKET_TYPES");
        }
    }
}
