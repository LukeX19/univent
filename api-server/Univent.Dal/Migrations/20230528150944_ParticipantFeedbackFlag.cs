using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univent.Dal.Migrations
{
    public partial class ParticipantFeedbackFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "hasProvidedFeedback",
                table: "EventParticipants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasProvidedFeedback",
                table: "EventParticipants");
        }
    }
}
