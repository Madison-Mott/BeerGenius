using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerGenius.Migrations
{
    public partial class RemovingIdentityrestartingwithbasicloginfeatures : Migration
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
                name: "UserFlavorProfiles",
                columns: table => new
                {
                    UserFlavorProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_UserFlavorProfiles", x => x.UserFlavorProfileId);
                    table.ForeignKey(
                        name: "FK_UserFlavorProfiles_BeerGeniusUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BeerGeniusUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFlavorProfiles_UserId",
                table: "UserFlavorProfiles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFlavorProfiles");

            migrationBuilder.DropTable(
                name: "BeerGeniusUsers");
        }
    }
}
