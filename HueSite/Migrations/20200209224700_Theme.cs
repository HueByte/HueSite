using Microsoft.EntityFrameworkCore.Migrations;

namespace HueSite.Migrations
{
    public partial class Theme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedTheme",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedTheme",
                table: "AspNetUsers");
        }
    }
}
