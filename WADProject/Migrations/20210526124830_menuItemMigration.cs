using Microsoft.EntityFrameworkCore.Migrations;

namespace WADProject.Migrations
{
    public partial class menuItemMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "MenuItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MenuItems");
        }
    }
}
