using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesApp.Migrations
{
    /// <inheritdoc />
    public partial class Verification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "StreamingPartners",
                columns: table => new
                {
                    EndpointId = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                    NewPartnerURL = table.Column<string>(type: "text", nullable: false),
                    ChallengeURL = table.Column<string>(type: "text", nullable: false),
                    VerificationStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamingPartners", x => x.EndpointId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Castings",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "integer", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "A", "Action" },
                    { "C", "Comedy" },
                    { "D", "Drama" },
                    { "H", "Horror" },
                    { "M", "Musical" },
                    { "R", "RomCom" },
                    { "S", "SciFi" }
                });

            migrationBuilder.InsertData(
                table: "StreamingPartners",
                columns: new[] { "EndpointId", "ChallengeURL", "NewPartnerURL", "VerificationStatus" },
                values: new object[] { 1, "https://localhost:7083/api/Challenge", "https://localhost:7083/api/Notification", "NOT VERIFIED" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "GenreId", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "D", "Casablanca", 1942 },
                    { 2, "A", "The Matrix", 1998 },
                    { 3, "C", "Pulp Fiction", 1992 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Castings_MovieId",
                table: "Castings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MovieId",
                table: "Review",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Castings");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "StreamingPartners");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
