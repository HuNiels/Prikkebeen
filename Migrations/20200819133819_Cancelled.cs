using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acupunctuur.Migrations
{
    public partial class Cancelled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Reservations");

            migrationBuilder.CreateTable(
                name: "Cancellations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CancelDate = table.Column<DateTime>(nullable: false),
                    ByAdmin = table.Column<bool>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false),
                    Done = table.Column<bool>(nullable: false),
                    CancelStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancellations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cancellations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_ReservationId",
                table: "Cancellations",
                column: "ReservationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cancellations");

            migrationBuilder.AddColumn<DateTime>(
                name: "Cancelled",
                table: "Reservations",
                type: "datetime2",
                nullable: true);
        }
    }
}
