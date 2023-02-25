using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univent.Dal.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_UserProfiles_UserID",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_UserProfiles_UserID",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_UserProfiles_UserID",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserProfiles",
                newName: "UserProfileID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Ratings",
                newName: "UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserID",
                table: "Ratings",
                newName: "IX_Ratings_UserProfileID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Events",
                newName: "UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Events_UserID",
                table: "Events",
                newName: "IX_Events_UserProfileID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "EventParticipants",
                newName: "UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipants_UserID",
                table: "EventParticipants",
                newName: "IX_EventParticipants_UserProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_UserProfiles_UserProfileID",
                table: "EventParticipants",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_UserProfiles_UserProfileID",
                table: "Events",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_UserProfiles_UserProfileID",
                table: "Ratings",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_UserProfiles_UserProfileID",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_UserProfiles_UserProfileID",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_UserProfiles_UserProfileID",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "UserProfileID",
                table: "UserProfiles",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "UserProfileID",
                table: "Ratings",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserProfileID",
                table: "Ratings",
                newName: "IX_Ratings_UserID");

            migrationBuilder.RenameColumn(
                name: "UserProfileID",
                table: "Events",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Events_UserProfileID",
                table: "Events",
                newName: "IX_Events_UserID");

            migrationBuilder.RenameColumn(
                name: "UserProfileID",
                table: "EventParticipants",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipants_UserProfileID",
                table: "EventParticipants",
                newName: "IX_EventParticipants_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_UserProfiles_UserID",
                table: "EventParticipants",
                column: "UserID",
                principalTable: "UserProfiles",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_UserProfiles_UserID",
                table: "Events",
                column: "UserID",
                principalTable: "UserProfiles",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_UserProfiles_UserID",
                table: "Ratings",
                column: "UserID",
                principalTable: "UserProfiles",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
