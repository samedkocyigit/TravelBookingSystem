using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelService.Migrations
{
    /// <inheritdoc />
    public partial class thirdUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Hotels_HotelId",
                table: "Facilities");

            migrationBuilder.AlterColumn<Guid>(
                name: "HotelId",
                table: "Facilities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FloorId",
                table: "Facilities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_FloorId",
                table: "Facilities",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Floors_FloorId",
                table: "Facilities",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Hotels_HotelId",
                table: "Facilities",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Floors_FloorId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Hotels_HotelId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_FloorId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "Facilities");

            migrationBuilder.AlterColumn<Guid>(
                name: "HotelId",
                table: "Facilities",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Hotels_HotelId",
                table: "Facilities",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
