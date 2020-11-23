using Microsoft.EntityFrameworkCore.Migrations;

namespace Acupunctuur.Migrations {
    public partial class TimeSlotLink : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeslotLinks_Timeslots_BaseId",
                table: "TimeslotLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeslotLinks_Timeslots_LinkId",
                table: "TimeslotLinks");

            migrationBuilder.AlterColumn<int>(
                name: "LinkId",
                table: "TimeslotLinks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaseId",
                table: "TimeslotLinks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeslotLinks_Timeslots_BaseId",
                table: "TimeslotLinks",
                column: "BaseId",
                principalTable: "Timeslots",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeslotLinks_Timeslots_LinkId",
                table: "TimeslotLinks",
                column: "LinkId",
                principalTable: "Timeslots",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeslotLinks_Timeslots_BaseId",
                table: "TimeslotLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeslotLinks_Timeslots_LinkId",
                table: "TimeslotLinks");

            migrationBuilder.AlterColumn<int>(
                name: "LinkId",
                table: "TimeslotLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BaseId",
                table: "TimeslotLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TimeslotLinks_Timeslots_BaseId",
                table: "TimeslotLinks",
                column: "BaseId",
                principalTable: "Timeslots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeslotLinks_Timeslots_LinkId",
                table: "TimeslotLinks",
                column: "LinkId",
                principalTable: "Timeslots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
