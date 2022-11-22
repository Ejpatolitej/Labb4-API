using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb4API.Migrations
{
    /// <inheritdoc />
    public partial class initmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestDescript = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestID);
                    table.ForeignKey(
                        name: "FK_Interests_people_PersonID",
                        column: x => x.PersonID,
                        principalTable: "people",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "Websites",
                columns: table => new
                {
                    WebsiteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebpageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: true),
                    PersonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Websites", x => x.WebsiteID);
                    table.ForeignKey(
                        name: "FK_Websites_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID");
                    table.ForeignKey(
                        name: "FK_Websites_people_PersonID",
                        column: x => x.PersonID,
                        principalTable: "people",
                        principalColumn: "PersonID");
                });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "PersonID", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Jack", "Niklasson", "0722211144" },
                    { 2, "Emma", "Whiteside", "0700021212" },
                    { 3, "Timothy", "Borgäng", "0731312224" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestID", "InterestDescript", "InterestTitle", "PersonID" },
                values: new object[,]
                {
                    { 1, "I Love Horses", "Horses", 1 },
                    { 2, "Computers are awesome", "Computers", 2 },
                    { 3, "I Mine all day...", "Minecraft", 3 }
                });

            migrationBuilder.InsertData(
                table: "Websites",
                columns: new[] { "WebsiteID", "InterestID", "PersonID", "WebpageLink" },
                values: new object[,]
                {
                    { 1, 1, 1, "www.Horse.com" },
                    { 3, 3, 2, "www.Minecraft.net/mine/all/day" },
                    { 4, 1, 3, "www.MoreHorses.pl" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonID",
                table: "Interests",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Websites_InterestID",
                table: "Websites",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_Websites_PersonID",
                table: "Websites",
                column: "PersonID",
                unique: true,
                filter: "[PersonID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Websites");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
