using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapinotesAPI.Migrations
{
    public partial class addeduseridcolumntoratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userID",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userID",
                table: "Ratings");
        }
    }
}
