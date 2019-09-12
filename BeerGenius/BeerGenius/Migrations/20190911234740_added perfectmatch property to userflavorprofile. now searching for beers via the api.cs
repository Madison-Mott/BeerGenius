using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerGenius.Migrations
{
    public partial class addedperfectmatchpropertytouserflavorprofilenowsearchingforbeersviatheapi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PerfectMatch",
                table: "UserFlavorProfiles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerfectMatch",
                table: "UserFlavorProfiles");
        }
    }
}
