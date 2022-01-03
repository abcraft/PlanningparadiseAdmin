using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanningParadiseAdmin.Data.Migrations
{
    public partial class wwaimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WWA_Img3",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WWA_Img4",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WWA_Img5",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WWA_Img6",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WWA_Img7",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WWA_Img8",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WWA_Img9",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUsVM");

            migrationBuilder.DropColumn(
                name: "WWA_Img3",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "WWA_Img4",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "WWA_Img5",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "WWA_Img6",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "WWA_Img7",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "WWA_Img8",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "WWA_Img9",
                table: "Home");
        }
    }
}
