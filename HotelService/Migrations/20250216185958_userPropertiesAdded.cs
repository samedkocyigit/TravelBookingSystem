using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelService.Migrations
{
    /// <inheritdoc />
    public partial class userPropertiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrentUserId",
                table: "Rooms",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "CustomerIds",
                table: "Hotels",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "ManagerIds",
                table: "Hotels",
                type: "uuid[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentUserId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CustomerIds",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "ManagerIds",
                table: "Hotels");
        }
    }
}
