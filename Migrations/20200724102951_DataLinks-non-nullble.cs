using Microsoft.EntityFrameworkCore.Migrations;

namespace Acupunctuur.Migrations {
    public partial class DataLinksnonnullble : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
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
        }
    }
}
