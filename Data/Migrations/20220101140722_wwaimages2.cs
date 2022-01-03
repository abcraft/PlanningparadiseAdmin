using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanningParadiseAdmin.Data.Migrations
{
    public partial class wwaimages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WWAImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WWA_Img1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WWA_Img2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WWA_Img3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WWA_Img4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WWA_Img5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WWA_Img6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WWA_Img7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WWA_Img8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WWA_Img9 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WWAImages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WWAImages");
        }
    }
}
