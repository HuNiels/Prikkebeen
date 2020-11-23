using Microsoft.EntityFrameworkCore.Migrations;

namespace Acupunctuur.Migrations {
    public partial class City : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PrivacyInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "City",
                table: "PrivacyInfo");
        }
    }
}
