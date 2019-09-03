using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerGenius.Migrations
{
    public partial class Addinguserflavorprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFlavorProfiles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_UserFlavorProfiles", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFlavorProfiles");
        }
    }
}
