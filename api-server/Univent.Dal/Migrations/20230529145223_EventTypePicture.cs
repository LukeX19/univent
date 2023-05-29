using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univent.Dal.Migrations
{
    public partial class EventTypePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "EventTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "EventTypes");
        }
    }
}
