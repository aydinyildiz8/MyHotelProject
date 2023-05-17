using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_05_add_booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingCheckin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingCheckout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingAdultCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingChildCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingRoomCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingRoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSpecialRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
