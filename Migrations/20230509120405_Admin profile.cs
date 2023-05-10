using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace merketo.Migrations
{
    /// <inheritdoc />
    public partial class Adminprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "74963dad-f36e-46b6-ac75-56be728d3ade", "a4d57c4d-2ca5-460d-92d6-0346701783da" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74963dad-f36e-46b6-ac75-56be728d3ade");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4d57c4d-2ca5-460d-92d6-0346701783da");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "74963dad-f36e-46b6-ac75-56be728d3ade", null, "SystemAdministrator", "SYSTEMADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a4d57c4d-2ca5-460d-92d6-0346701783da", 0, "f0ba4dd4-bf95-4713-a88e-91b72c91d4f9", "administrator", false, "system", "admin", false, null, null, null, "AQAAAAIAAYagAAAAECS/jv7qqpgC/dVj78BfojSMpQQaqDebTzyLblsDI95fE5JtbQ8KGuDsYGILshzHeA==", null, false, "e4499f70-ef3b-44cb-89d4-15b644fc0fb4", false, "administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "74963dad-f36e-46b6-ac75-56be728d3ade", "a4d57c4d-2ca5-460d-92d6-0346701783da" });
        }
    }
}
