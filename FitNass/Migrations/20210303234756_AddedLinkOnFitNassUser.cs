using Microsoft.EntityFrameworkCore.Migrations;

namespace FitNass.Migrations
{
    public partial class AddedLinkOnFitNassUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "AspNetUsers");
        }
    }
}
