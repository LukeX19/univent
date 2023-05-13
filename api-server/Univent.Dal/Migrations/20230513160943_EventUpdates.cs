using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univent.Dal.Migrations
{
    public partial class EventUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LocationLat",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LocationLng",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationLat",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LocationLng",
                table: "Events");
        }
    }
}
