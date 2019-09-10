using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerGenius.Migrations
{
    public partial class AddedTimesMatchedintoFlavorProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimesSelected",
                table: "FlavorProfiles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimesSelected",
                table: "FlavorProfiles");
        }
    }
}
