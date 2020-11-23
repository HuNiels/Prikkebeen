using Microsoft.EntityFrameworkCore.Migrations;

namespace Acupunctuur.Migrations
{
    public partial class customerMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerMessage",
                table: "BlockedPeriods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerMessage",
                table: "BlockedPeriods");
        }
    }
}
