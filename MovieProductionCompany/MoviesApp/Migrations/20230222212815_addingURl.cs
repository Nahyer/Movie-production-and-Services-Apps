using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Rebus.Sagas;

#nullable disable

namespace MoviesApp.Migrations
{
    /// <inheritdoc />
    public partial class addingURl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StreamingPartners",
                columns: table => new
                {
                    EndpointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewPartnerURL = table.Column<string>(type: "varchar", nullable: false),
                    ChallengeURL = table.Column<string>(type: "varchar", nullable: false),
					APIkey = table.Column<string>(type: "varchar", nullable: false)
				},
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamingPartners", x => x.EndpointId);
                });

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StreamingPartners");
        }
    }
}
