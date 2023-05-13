using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutRoomCount = table.Column<int>(type: "int", nullable: false),
                    AboutStaffCount = table.Column<int>(type: "int", nullable: false),
                    AboutCustomerCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");
        }
    }
}
