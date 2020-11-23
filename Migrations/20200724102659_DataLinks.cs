using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Acupunctuur.Migrations {
    public partial class DataLinks : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AlterColumn<int>(
                name: "LinkId",
                table: "TimeslotLinks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BaseId",
                table: "TimeslotLinks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "DoubleSlot", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, false, new TimeSpan(0, 9, 15, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 2, false, new TimeSpan(0, 10, 15, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 3, true, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 4, false, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 45, 0, 0) },
                    { 5, false, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 45, 0, 0) },
                    { 6, true, new TimeSpan(0, 12, 15, 0, 0), new TimeSpan(0, 10, 45, 0, 0) },
                    { 7, false, new TimeSpan(0, 14, 15, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 8, false, new TimeSpan(0, 15, 15, 0, 0), new TimeSpan(0, 14, 30, 0, 0) },
                    { 9, false, new TimeSpan(0, 16, 15, 0, 0), new TimeSpan(0, 15, 30, 0, 0) },
                    { 10, true, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 14, 30, 0, 0) },
                    { 11, false, new TimeSpan(0, 17, 15, 0, 0), new TimeSpan(0, 16, 30, 0, 0) },
                    { 12, false, new TimeSpan(0, 19, 45, 0, 0), new TimeSpan(0, 19, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "TimeslotLinks",
                columns: new[] { "Id", "BaseId", "LinkId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 3 },
                    { 3, 3, 1 },
                    { 4, 3, 2 },
                    { 5, 4, 6 },
                    { 6, 5, 6 },
                    { 7, 6, 4 },
                    { 8, 6, 5 },
                    { 9, 8, 10 },
                    { 10, 9, 10 },
                    { 11, 10, 8 },
                    { 12, 10, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TimeslotLinks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 12);

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

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<int>(
                name: "LinkId",
                table: "TimeslotLinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaseId",
                table: "TimeslotLinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
