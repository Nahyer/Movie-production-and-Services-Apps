using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesApp.Migrations
{
    /// <inheritdoc />
    public partial class StreamingState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Streams",
                columns: table => new
                {
                    StreamId = table.Column<bool>(type: "boolean", nullable: false),
                    StreamingStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.StreamId);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    ProductionStudioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.ProductionStudioId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<string>(type: "text", nullable: false),
                    ProductionStudioId = table.Column<int>(type: "integer", nullable: false),
                    StreamId = table.Column<bool>(type: "boolean", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Movies_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "StreamId");
                    table.ForeignKey(
                        name: "FK_Movies_Studios_ProductionStudioId",
                        column: x => x.ProductionStudioId,
                        principalTable: "Studios",
                        principalColumn: "ProductionStudioId",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Streams",
                columns: new[] { "StreamId", "StreamingStatus" },
                values: new object[,]
                {
                    { false, "Not Streaming" },
                    { true, "ActivelyStreaming" }
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "ProductionStudioId", "Name" },
                values: new object[,]
                {
                    { 1, "Warner Brothers" },
                    { 2, "MPC Productions" },
                    { 3, "Rollins and Joffe Productions" },
                    { 4, "Omni Zoetrope" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "GenreId", "Name", "ProductionStudioId", "Rating", "StreamId", "Year" },
                values: new object[,]
                {
                    { 1, "D", "Casablanca", 1, 5, true, 1942 },
                    { 2, "A", "Apocalypse Now", 4, 4, true, 1979 },
                    { 3, "C", "Annie Hall", 3, 5, true, 1977 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProductionStudioId",
                table: "Movies",
                column: "ProductionStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_StreamId",
                table: "Movies",
                column: "StreamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Streams");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
