using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanningParadiseAdmin.Data.Migrations
{
    public partial class DestinationsText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination_Text",
                table: "DestinationWedding",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination_Text",
                table: "DestinationWedding");
        }
    }
}
