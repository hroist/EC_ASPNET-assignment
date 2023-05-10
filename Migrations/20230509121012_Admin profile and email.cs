using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace merketo.Migrations
{
    /// <inheritdoc />
    public partial class Adminprofileandemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetProfiles",
                keyColumn: "UserId",
                keyValue: "f746d9ba-4958-420b-b569-a2c82cab25c6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df0a06fb-5ab7-49e5-8a87-7e583fc4110b", "f746d9ba-4958-420b-b569-a2c82cab25c6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df0a06fb-5ab7-49e5-8a87-7e583fc4110b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f746d9ba-4958-420b-b569-a2c82cab25c6");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "df0a06fb-5ab7-49e5-8a87-7e583fc4110b", null, "SystemAdministrator", "SYSTEMADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f746d9ba-4958-420b-b569-a2c82cab25c6", 0, "d94a7946-330e-45ed-a6a0-ab5f8c60feb9", "administrator", false, "system", "admin", false, null, null, null, "AQAAAAIAAYagAAAAEKjsLoHFdvpSCZhIF5PcZYgfCSaQ3OdA4aLwQVs7DvYnfRNqpvrbo4FMQsUUfEQ+yg==", null, false, "e188dd0c-f449-424b-aced-e0877baa465a", false, "administrator" });

            migrationBuilder.InsertData(
                table: "AspNetProfiles",
                columns: new[] { "UserId", "City", "CompanyName", "PostalCode", "ProfilePictureURL", "StreetName" },
                values: new object[] { "f746d9ba-4958-420b-b569-a2c82cab25c6", "admin", null, "admin", null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "df0a06fb-5ab7-49e5-8a87-7e583fc4110b", "f746d9ba-4958-420b-b569-a2c82cab25c6" });
        }
    }
}
