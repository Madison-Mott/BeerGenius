using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerGenius.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeerGeniusUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerGeniusUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FlavorProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BreweryDbId = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "UserFlavorProfiles",
                columns: table => new
                {
                    UserFlavorProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    Crisp = table.Column<int>(nullable: false),
                    Hop = table.Column<int>(nullable: false),
                    Malt = table.Column<int>(nullable: false),
                    Fruity = table.Column<int>(nullable: false),
                    Sour = table.Column<int>(nullable: false),
                    ABV = table.Column<int>(nullable: false),
                    Roasty = table.Column<int>(nullable: false),
                    Sweetness = table.Column<int>(nullable: false),
                    MatchingFlavorProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFlavorProfiles", x => x.UserFlavorProfileId);
                    table.ForeignKey(
                        name: "FK_UserFlavorProfiles_BeerGeniusUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BeerGeniusUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FlavorProfiles",
                columns: new[] { "Id", "ABV", "BreweryDbId", "Color", "Crisp", "Fruity", "Hop", "Malt", "Roasty", "Sour", "Sweetness" },
                values: new object[,]
                {
                    { 1, 2, 1, 2, 2, 2, 3, 2, 1, 1, 1 },
                    { 70, 1, 77, 1, 3, 1, 2, 1, 1, 1, 1 },
                    { 69, 2, 76, 1, 3, 1, 2, 2, 2, 1, 1 },
                    { 68, 2, 75, 1, 3, 1, 2, 1, 1, 1, 2 },
                    { 67, 2, 74, 2, 2, 3, 2, 1, 1, 1, 2 },
                    { 66, 2, 73, 2, 2, 3, 3, 1, 1, 1, 1 },
                    { 65, 2, 72, 2, 2, 2, 2, 1, 1, 2, 2 },
                    { 64, 2, 71, 2, 2, 2, 2, 3, 3, 2, 2 },
                    { 63, 1, 69, 2, 3, 2, 1, 1, 1, 2, 2 },
                    { 62, 2, 68, 1, 3, 3, 1, 1, 1, 3, 2 },
                    { 71, 2, 78, 1, 3, 1, 1, 2, 1, 1, 1 },
                    { 61, 2, 67, 1, 3, 3, 1, 1, 1, 3, 1 },
                    { 59, 2, 65, 1, 2, 2, 1, 1, 1, 1, 2 },
                    { 58, 3, 64, 2, 1, 3, 2, 3, 1, 1, 3 },
                    { 57, 3, 63, 2, 1, 3, 2, 1, 1, 1, 3 },
                    { 56, 2, 62, 2, 2, 2, 2, 1, 1, 1, 2 },
                    { 55, 2, 61, 2, 2, 2, 1, 1, 1, 1, 2 },
                    { 54, 3, 60, 2, 2, 3, 2, 2, 2, 2, 2 },
                    { 53, 3, 59, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 52, 2, 58, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 51, 2, 57, 2, 2, 2, 1, 1, 2, 3, 1 },
                    { 60, 2, 66, 1, 3, 3, 1, 1, 1, 2, 2 },
                    { 50, 2, 55, 2, 3, 1, 1, 1, 1, 1, 1 },
                    { 72, 2, 79, 1, 3, 1, 1, 1, 1, 1, 1 },
                    { 74, 2, 81, 2, 2, 1, 1, 3, 2, 1, 2 },
                    { 94, 3, 115, 2, 2, 2, 1, 2, 2, 1, 2 },
                    { 93, 2, 114, 2, 2, 3, 1, 2, 1, 1, 2 },
                    { 92, 2, 109, 1, 3, 1, 1, 1, 1, 1, 2 },
                    { 91, 1, 105, 1, 3, 1, 1, 1, 1, 1, 2 },
                    { 90, 3, 104, 3, 1, 2, 1, 3, 2, 1, 2 },
                    { 89, 2, 103, 3, 2, 1, 1, 3, 2, 1, 1 },
                    { 88, 2, 102, 2, 2, 1, 2, 3, 2, 1, 2 },
                    { 87, 2, 101, 2, 2, 1, 2, 3, 1, 1, 1 },
                    { 86, 2, 98, 1, 3, 1, 2, 1, 1, 1, 1 },
                    { 73, 2, 80, 2, 3, 1, 1, 2, 2, 1, 2 },
                    { 85, 1, 95, 1, 3, 1, 1, 1, 1, 1, 1 },
                    { 83, 2, 93, 1, 3, 1, 1, 1, 1, 1, 1 },
                    { 82, 3, 90, 3, 1, 2, 2, 3, 3, 1, 2 },
                    { 81, 2, 89, 1, 1, 1, 2, 3, 2, 1, 2 },
                    { 80, 2, 88, 3, 1, 1, 1, 3, 3, 1, 2 },
                    { 79, 2, 86, 1, 1, 1, 1, 2, 3, 1, 2 },
                    { 78, 2, 85, 2, 1, 1, 1, 3, 2, 1, 2 },
                    { 77, 2, 84, 2, 2, 1, 2, 3, 2, 1, 2 },
                    { 76, 2, 83, 2, 2, 1, 1, 2, 2, 1, 2 },
                    { 75, 2, 82, 2, 2, 1, 1, 3, 2, 1, 2 },
                    { 84, 1, 94, 1, 3, 1, 1, 1, 1, 1, 1 },
                    { 49, 2, 54, 2, 2, 3, 1, 2, 1, 1, 2 },
                    { 48, 3, 53, 2, 2, 2, 1, 2, 2, 1, 2 },
                    { 47, 2, 52, 2, 2, 2, 1, 2, 2, 1, 2 },
                    { 21, 2, 21, 3, 1, 1, 1, 3, 3, 1, 2 },
                    { 20, 2, 20, 2, 1, 2, 2, 3, 2, 1, 3 },
                    { 19, 2, 19, 3, 1, 2, 2, 3, 2, 1, 2 },
                    { 18, 2, 18, 2, 1, 2, 2, 3, 1, 1, 1 },
                    { 17, 3, 17, 2, 1, 3, 1, 3, 1, 1, 2 },
                    { 16, 3, 16, 3, 1, 2, 2, 3, 1, 1, 2 },
                    { 15, 3, 15, 2, 1, 1, 1, 3, 3, 1, 3 },
                    { 14, 3, 14, 2, 1, 2, 1, 3, 2, 1, 2 },
                    { 13, 2, 13, 2, 1, 2, 1, 3, 2, 1, 2 },
                    { 22, 2, 22, 2, 2, 1, 2, 2, 2, 1, 2 },
                    { 12, 2, 12, 2, 1, 1, 1, 3, 2, 1, 2 },
                    { 10, 1, 10, 2, 2, 1, 1, 3, 2, 1, 1 },
                    { 9, 1, 9, 2, 2, 2, 1, 2, 2, 1, 2 },
                    { 8, 1, 8, 2, 2, 1, 1, 2, 2, 1, 1 },
                    { 7, 1, 7, 1, 2, 1, 1, 2, 2, 1, 1 },
                    { 6, 2, 6, 1, 2, 1, 3, 1, 2, 1, 1 },
                    { 5, 2, 5, 2, 2, 1, 3, 2, 2, 1, 2 },
                    { 4, 2, 4, 2, 2, 1, 3, 2, 2, 1, 1 },
                    { 3, 2, 3, 2, 2, 1, 3, 2, 1, 1, 1 },
                    { 2, 2, 2, 2, 2, 3, 3, 2, 1, 1, 1 },
                    { 11, 1, 11, 3, 1, 1, 1, 3, 2, 1, 1 },
                    { 23, 2, 23, 3, 1, 1, 3, 3, 3, 1, 2 },
                    { 24, 3, 24, 3, 1, 1, 3, 2, 2, 1, 2 },
                    { 25, 2, 25, 2, 2, 3, 3, 2, 1, 1, 1 },
                    { 46, 2, 51, 2, 2, 2, 1, 2, 1, 1, 2 },
                    { 45, 1, 50, 1, 2, 2, 1, 1, 1, 1, 1 },
                    { 44, 2, 49, 1, 2, 2, 1, 1, 1, 2, 2 },
                    { 43, 2, 48, 1, 2, 3, 1, 1, 1, 2, 2 },
                    { 42, 2, 47, 1, 3, 3, 1, 1, 1, 3, 2 },
                    { 41, 1, 46, 1, 3, 2, 1, 1, 1, 2, 1 },
                    { 40, 2, 45, 1, 3, 1, 2, 1, 1, 1, 1 },
                    { 39, 3, 44, 3, 1, 2, 2, 2, 2, 1, 1 },
                    { 38, 3, 43, 3, 1, 2, 3, 3, 3, 1, 2 },
                    { 37, 2, 42, 3, 1, 1, 3, 2, 3, 1, 1 },
                    { 36, 2, 41, 3, 1, 2, 3, 2, 2, 1, 1 },
                    { 35, 2, 38, 3, 1, 1, 2, 3, 1, 1, 2 },
                    { 34, 2, 37, 2, 2, 1, 1, 2, 2, 1, 1 },
                    { 33, 2, 36, 1, 3, 1, 1, 2, 1, 1, 2 },
                    { 32, 3, 35, 2, 1, 3, 2, 3, 1, 1, 1 },
                    { 31, 3, 34, 2, 1, 3, 3, 3, 1, 1, 1 },
                    { 30, 3, 33, 2, 1, 1, 3, 3, 2, 1, 1 },
                    { 29, 2, 32, 2, 1, 1, 2, 3, 2, 1, 1 },
                    { 28, 3, 31, 2, 2, 3, 3, 1, 1, 1, 1 },
                    { 27, 2, 30, 2, 3, 2, 3, 1, 1, 1, 1 },
                    { 26, 2, 29, 2, 2, 2, 3, 1, 1, 1, 1 },
                    { 95, 3, 116, 3, 2, 2, 1, 2, 2, 1, 2 },
                    { 96, 3, 117, 3, 2, 2, 1, 2, 2, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFlavorProfiles_UserId",
                table: "UserFlavorProfiles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlavorProfiles");

            migrationBuilder.DropTable(
                name: "UserFlavorProfiles");

            migrationBuilder.DropTable(
                name: "BeerGeniusUsers");
        }
    }
}
