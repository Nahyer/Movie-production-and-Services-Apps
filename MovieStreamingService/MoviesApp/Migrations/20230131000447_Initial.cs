using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "varchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    ProductionStudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.ProductionStudioId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<string>(type: "varchar(450)", nullable: false),
                    ProductionStudioId = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "MovieId", "GenreId", "Name", "ProductionStudioId", "Rating", "Year" },
                values: new object[,]
                {
                    { 1, "D", "Casablanca", 1, 5, 1942 },
                    { 2, "A", "Apocalypse Now", 4, 4, 1979 },
                    { 3, "C", "Annie Hall", 3, 5, 1977 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProductionStudioId",
                table: "Movies",
                column: "ProductionStudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
