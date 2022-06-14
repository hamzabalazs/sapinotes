using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapinotesAPI.Migrations
{
    public partial class addedusernamecolumntonotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "Notes");
        }
    }
}
