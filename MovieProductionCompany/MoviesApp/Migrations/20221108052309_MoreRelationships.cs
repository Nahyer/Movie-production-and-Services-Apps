using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MoviesApp.Migrations
{
    public partial class MoreRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "varchar", nullable: true),
                    LastName = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "varchar", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Castings",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Castings", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Castings_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Castings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Humphrey", "Bogart" },
                    { 2, "Ingrid", "Bergman" },
                    { 3, "Keanu", "Reeves" },
                    { 4, "Carrie-Anne", "Moss" },
                    { 5, "John", "Travolta" },
                    { 6, "Uma", "Thurman" }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                columns: new[] { "Name", "Year" },
                values: new object[] { "The Matrix", 1998 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                columns: new[] { "Name", "Year" },
                values: new object[] { "Pulp Fiction", 1992 });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comments", "MovieId", "Rating" },
                values: new object[,]
                {
                    { 1, "A classic!", 1, 5 },
                    { 2, "They should have gotten together in the end!", 1, 3 },
                    { 3, "Too slow of a pace", 1, 3 },
                    { 4, "Based on Descarte's \"brain in a vat\" thought experiment", 2, 4 },
                    { 5, "Very philosophical", 2, 3 },
                    { 6, "Very violent but also very funny and clever", 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Castings",
                columns: new[] { "ActorId", "MovieId", "Role" },
                values: new object[,]
                {
                    { 1, 1, "Rick Blaine" },
                    { 2, 1, "Ilsa Lund" },
                    { 3, 2, "Neo" },
                    { 4, 2, "Trinity" },
                    { 5, 3, "Vincet Vega" },
                    { 6, 3, "Mia Wallace" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Castings_MovieId",
                table: "Castings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MovieId",
                table: "Review",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Castings");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                columns: new[] { "Name", "Rating", "Year" },
                values: new object[] { "Apocalypse Now", 4, 1979 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                columns: new[] { "Name", "Rating", "Year" },
                values: new object[] { "Annie Hall", 5, 1977 });
        }
    }
}
