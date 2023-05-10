using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace merketo.Migrations
{
    /// <inheritdoc />
    public partial class Adminnormalizedemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetProfiles",
                keyColumn: "UserId",
                keyValue: "48dfdc9b-0d2e-4627-b584-9969d765e073");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d8cff07-15bd-421b-9726-fcfde09348b0", "48dfdc9b-0d2e-4627-b584-9969d765e073" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d8cff07-15bd-421b-9726-fcfde09348b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48dfdc9b-0d2e-4627-b584-9969d765e073");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e56ee702-fdc7-4427-8d48-a75cb1c5eeff", null, "SystemAdministrator", "SYSTEMADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d4f1121b-3953-4417-8f67-a686204f440e", 0, "f390bf1d-bdbb-4c86-adb5-6ee485f55d89", "admin", false, "system", "admin", false, null, "ADMIN", "ADMIN", "AQAAAAIAAYagAAAAEDpor1fmSWQlrxK8tl6SQVmq8jFlsOfoY65JMLwpI46769+GrsfjyyH1Fa3EPw/NOQ==", null, false, "ae1e0898-8646-40db-9c78-023f996319a4", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetProfiles",
                columns: new[] { "UserId", "City", "CompanyName", "PostalCode", "ProfilePictureURL", "StreetName" },
                values: new object[] { "d4f1121b-3953-4417-8f67-a686204f440e", "admin", null, "admin", null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e56ee702-fdc7-4427-8d48-a75cb1c5eeff", "d4f1121b-3953-4417-8f67-a686204f440e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetProfiles",
                keyColumn: "UserId",
                keyValue: "d4f1121b-3953-4417-8f67-a686204f440e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e56ee702-fdc7-4427-8d48-a75cb1c5eeff", "d4f1121b-3953-4417-8f67-a686204f440e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e56ee702-fdc7-4427-8d48-a75cb1c5eeff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4f1121b-3953-4417-8f67-a686204f440e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d8cff07-15bd-421b-9726-fcfde09348b0", null, "SystemAdministrator", "SYSTEMADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "48dfdc9b-0d2e-4627-b584-9969d765e073", 0, "515a1545-a928-406a-85be-28980bb89277", "admin@admin.com", false, "system", "admin", false, null, null, null, "AQAAAAIAAYagAAAAEFnVGrBCarfUqKG2RqHb1XXBl70JGBnAI2Ru/PqMntzeWVga1i/0lZQG9lHRvjZ4GA==", null, false, "0f767240-5b7c-4a67-aa93-2482cf8eb97c", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetProfiles",
                columns: new[] { "UserId", "City", "CompanyName", "PostalCode", "ProfilePictureURL", "StreetName" },
                values: new object[] { "48dfdc9b-0d2e-4627-b584-9969d765e073", "admin", null, "admin", null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3d8cff07-15bd-421b-9726-fcfde09348b0", "48dfdc9b-0d2e-4627-b584-9969d765e073" });
        }
    }
}
