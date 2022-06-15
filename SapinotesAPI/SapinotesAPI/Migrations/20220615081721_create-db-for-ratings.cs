using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapinotesAPI.Migrations
{
    public partial class createdbforratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "noteRatingValue",
                table: "Notes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "numberOfRatings",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    ratingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    noteID = table.Column<int>(type: "int", nullable: false),
                    ratingValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.ratingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropColumn(
                name: "noteRatingValue",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "numberOfRatings",
                table: "Notes");
        }
    }
}
