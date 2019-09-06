using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerGenius.Migrations
{
    public partial class alteredflavorprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aroma",
                table: "UserFlavorProfiles");

            migrationBuilder.DropColumn(
                name: "Aroma",
                table: "FlavorProfiles");

            migrationBuilder.UpdateData(
                table: "FlavorProfiles",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ABV", "Color", "Crisp", "Hop", "Malt", "Roasty", "Sour", "Sweetness" },
                values: new object[] { 3, 3, 1, 2, 3, 3, 1, 2 });

            migrationBuilder.UpdateData(
                table: "FlavorProfiles",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ABV", "Color", "Crisp", "Fruity", "Hop", "Malt", "Roasty", "Sour", "Sweetness" },
                values: new object[] { 3, 1, 1, 3, 1, 3, 2, 1, 3 });

            migrationBuilder.UpdateData(
                table: "FlavorProfiles",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ABV", "Color", "Crisp", "Fruity", "Roasty", "Sour", "Sweetness" },
                values: new object[] { 2, 1, 3, 3, 1, 2, 2 });

            migrationBuilder.UpdateData(
                table: "FlavorProfiles",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ABV", "Crisp", "Hop", "Malt", "Roasty", "Sour" },
                values: new object[] { 1, 3, 2, 1, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Aroma",
                table: "UserFlavorProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Aroma",
                table: "FlavorProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FlavorProfiles",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ABV", "Aroma", "Color", "Crisp", "Hop", "Malt", "Roasty", "Sour", "Sweetness" },
                values: new object[] { 8, 10, 10, 0, 5, 10, 8, 0, 4 });

            migrationBuilder.UpdateData(
                table: "FlavorProfiles",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ABV", "Aroma", "Color", "Crisp", "Fruity", "Hop", "Malt", "Roasty", "Sour", "Sweetness" },
                values: new object[] { 10, 7, 3, 0, 8, 3, 8, 4, 0, 7 });

            migrationBuilder.UpdateData(
                table: "FlavorProfiles",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ABV", "Aroma", "Color", "Crisp", "Fruity", "Roasty", "Sour", "Sweetness" },
                values: new object[] { 6, 1, 2, 7, 10, 0, 6, 6 });

            migrationBuilder.UpdateData(
                table: "FlavorProfiles",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ABV", "Aroma", "Crisp", "Hop", "Malt", "Roasty", "Sour" },
                values: new object[] { 3, 3, 8, 4, 2, 0, 0 });
        }
    }
}
