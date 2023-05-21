using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_07_update_contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactSurnameName",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactSurnameName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
