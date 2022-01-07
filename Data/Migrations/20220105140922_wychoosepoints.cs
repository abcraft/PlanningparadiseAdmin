using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanningParadiseAdmin.Data.Migrations
{
    public partial class wychoosepoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WWA_Img1",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "WWA_Img2",
                table: "Home");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WWA_Img1",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WWA_Img2",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}
