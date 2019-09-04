using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerGenius.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlavorProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<int>(nullable: false),
                    Aroma = table.Column<int>(nullable: false),
                    Crisp = table.Column<int>(nullable: false),
                    Hop = table.Column<int>(nullable: false),
                    Malt = table.Column<int>(nullable: false),
                    Fruity = table.Column<int>(nullable: false),
                    Sour = table.Column<int>(nullable: false),
                    ABV = table.Column<int>(nullable: false),
                    Roasty = table.Column<int>(nullable: false),
                    Sweetness = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlavorProfiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FlavorProfiles",
                columns: new[] { "Id", "ABV", "Aroma", "Color", "Crisp", "Fruity", "Hop", "Malt", "Roasty", "Sour", "Sweetness" },
                values: new object[,]
                {
                    { 66, 6, 1, 2, 7, 10, 1, 1, 0, 6, 6 },
                    { 43, 8, 10, 10, 0, 1, 5, 10, 8, 0, 4 },
                    { 75, 3, 3, 1, 8, 1, 4, 2, 0, 0, 1 },
                    { 60, 10, 7, 3, 0, 8, 3, 8, 4, 0, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlavorProfiles");
        }
    }
}
