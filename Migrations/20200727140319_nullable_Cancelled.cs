using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Acupunctuur.Migrations {
    public partial class nullable_Cancelled : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Cancelled",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Cancelled",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
