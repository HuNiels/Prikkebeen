using Microsoft.EntityFrameworkCore.Migrations;

namespace Acupunctuur.Migrations {
    public partial class New : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<bool>(
                name: "NewUser",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "NewUser",
                table: "Users");
        }
    }
}
