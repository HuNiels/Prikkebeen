using Microsoft.EntityFrameworkCore.Migrations;

namespace Acupunctuur.Migrations {
    public partial class PrivacyInformation : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserPrivacyInfoId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PrivacyInfo",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(nullable: true),
                    HouseAddress = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_PrivacyInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserPrivacyInfoId",
                table: "Users",
                column: "UserPrivacyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PrivacyInfo_UserPrivacyInfoId",
                table: "Users",
                column: "UserPrivacyInfoId",
                principalTable: "PrivacyInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PrivacyInfo_UserPrivacyInfoId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "PrivacyInfo");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserPrivacyInfoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserPrivacyInfoId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
