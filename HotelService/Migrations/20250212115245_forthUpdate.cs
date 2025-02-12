using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelService.Migrations
{
    /// <inheritdoc />
    public partial class forthUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Hotels_HotelId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_HotelId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Facilities");

            migrationBuilder.AddColumn<int>(
                name: "RoomCapacity",
                table: "Hotels",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomCapacity",
                table: "Hotels");

            migrationBuilder.AddColumn<Guid>(
                name: "HotelId",
                table: "Facilities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_HotelId",
                table: "Facilities",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Hotels_HotelId",
                table: "Facilities",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
