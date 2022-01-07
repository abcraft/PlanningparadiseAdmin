using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanningParadiseAdmin.Data.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUsVM");

            migrationBuilder.CreateTable(
                name: "WhyChoosePoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhyChoosePoints", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhyChoosePoints");

            migrationBuilder.CreateTable(
                name: "AboutUsVM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    About_Heading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About_Para1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About_Para2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About_Para3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About_Qoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsVM", x => x.ID);
                });
        }
    }
}
