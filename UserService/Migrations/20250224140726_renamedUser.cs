using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    /// <inheritdoc />
    public partial class renamedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelIds",
                table: "Users",
                newName: "HotelBookingIds");

            migrationBuilder.RenameColumn(
                name: "FlightIds",
                table: "Users",
                newName: "FlightBookingIds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelBookingIds",
                table: "Users",
                newName: "HotelIds");

            migrationBuilder.RenameColumn(
                name: "FlightBookingIds",
                table: "Users",
                newName: "FlightIds");
        }
    }
}
