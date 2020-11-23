using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Acupunctuur.Migrations {
    public partial class TimeSlotsAdded : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "DoubleSlot", "EndTime", "StartTime" },
                values: new object[] { 1, false, new TimeSpan(0, 9, 15, 0, 0), new TimeSpan(0, 8, 30, 0, 0) });

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "DoubleSlot", "EndTime", "StartTime" },
                values: new object[] { 2, false, new TimeSpan(0, 10, 15, 0, 0), new TimeSpan(0, 9, 30, 0, 0) });

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "DoubleSlot", "EndTime", "StartTime" },
                values: new object[] { 3, true, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 30, 0, 0) });
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
