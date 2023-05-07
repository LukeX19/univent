using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univent.Dal.Migrations
{
    public partial class CreateAdminAccounts : Migration
    {
        private readonly Guid adminUniversityId = Guid.NewGuid();
        private readonly Guid adminIdentityId = Guid.NewGuid();
        private readonly Guid adminProfileId = Guid.NewGuid();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Add Admin University
            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "UniversityID", "Name" },
                values: new object[] { adminUniversityId.ToString(), "Admin" });

            //Add Identity User for Admin
            var hasher = new PasswordHasher<IdentityUser>();
            var admin = new IdentityUser
            {
                Id = adminIdentityId.ToString(),
                UserName = "admin1@uniev.com",
                NormalizedUserName = "ADMIN1@UNIEV.COM",
                Email = "admin1@uniev.com",
                NormalizedEmail = "ADMIN1@UNIEV.COM",
                PasswordHash = hasher.HashPassword(null, "PassAdminUniEv1!"),
            };
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed",
                    "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed",
                    "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount"},
                values: new object[] { admin.Id, admin.UserName, admin.NormalizedUserName, admin.Email, admin.NormalizedEmail, admin.EmailConfirmed,
                    admin.PasswordHash, admin.SecurityStamp, admin.ConcurrencyStamp, admin.PhoneNumber, admin.PhoneNumberConfirmed,
                    admin.TwoFactorEnabled, admin.LockoutEnd, admin.LockoutEnabled, admin.AccessFailedCount});

            //Add Admin User Profile
            var adminProfile = new
            {
                UserProfileID = adminProfileId,
                UniversityID = adminUniversityId,
                IdentityID = admin.Id,
                Year = "0",
                BasicInfo_FirstName = "Admin1",
                BasicInfo_LastName = "Admin1",
                BasicInfo_EmailAddress = admin.UserName,
                BasicInfo_PhoneNumber = "9999999999",
                BasicInfo_DateOfBirth = DateTime.UtcNow.AddYears(-40),
                BasicInfo_Hometown = "AdminCity",
                CreatedDate = DateTime.UtcNow
            };
            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "UserProfileID", "UniversityID", "IdentityID", "Year", "BasicInfo_FirstName", "BasicInfo_LastName",
                    "BasicInfo_EmailAddress", "BasicInfo_PhoneNumber", "BasicInfo_DateOfBirth", "BasicInfo_Hometown", "CreatedDate" },
                values: new object[] { adminProfile.UserProfileID, adminProfile.UniversityID, adminProfile.IdentityID, adminProfile.Year, 
                    adminProfile.BasicInfo_FirstName, adminProfile.BasicInfo_LastName, adminProfile.BasicInfo_EmailAddress, adminProfile.BasicInfo_PhoneNumber,
                    adminProfile.BasicInfo_DateOfBirth, adminProfile.BasicInfo_Hometown, adminProfile.CreatedDate });

            //Add the newly created user to Admin role
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { admin.Id, "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Delete the user from Admin role
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { adminIdentityId.ToString(), "1" });

            //Delete Admin User Profile
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserProfileID",
                keyValue: adminProfileId);

            //Delete Admin Identity User
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: adminIdentityId.ToString());

            //Delete Admin University
            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: adminUniversityId.ToString());
        }
    }
}
