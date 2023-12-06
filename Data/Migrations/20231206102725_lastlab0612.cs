using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class lastlab0612 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ac3eaa98-b50e-47e5-9d1c-da0bf9e49755", "7db0b162-e56a-4a63-a8c1-1ea091eeacbb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac3eaa98-b50e-47e5-9d1c-da0bf9e49755");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7db0b162-e56a-4a63-a8c1-1ea091eeacbb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64f43a5e-f114-4625-8b81-03e27c7a4074", "64f43a5e-f114-4625-8b81-03e27c7a4074", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "74bfa5ad-1eb1-465e-a745-54167284eb7d", 0, "80bf3991-9588-4673-b74a-ca32bebaa798", "bartek@wsei.pl", true, false, null, "BARTEK@WSEI.PL", "BARTEK", "AQAAAAEAACcQAAAAENOhegYqUr9VusCZdK9pQj2KBnRWmvFDMM7b9U1Ih3WUDmVbaY85CZyDcOQ6chOhBQ==", null, false, "bcdf291c-79b6-4af4-9826-cd76198d8fac", false, "bartek" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "64f43a5e-f114-4625-8b81-03e27c7a4074", "74bfa5ad-1eb1-465e-a745-54167284eb7d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64f43a5e-f114-4625-8b81-03e27c7a4074", "74bfa5ad-1eb1-465e-a745-54167284eb7d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64f43a5e-f114-4625-8b81-03e27c7a4074");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "74bfa5ad-1eb1-465e-a745-54167284eb7d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac3eaa98-b50e-47e5-9d1c-da0bf9e49755", "ac3eaa98-b50e-47e5-9d1c-da0bf9e49755", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7db0b162-e56a-4a63-a8c1-1ea091eeacbb", 0, "b33f5e42-8592-466e-b3e4-c0261c1546fe", "bartek@wsei.pl", true, false, null, "BARTEK@WSEI.PL", "BARTEK", "AQAAAAEAACcQAAAAEOBNxXm4RxvqLUKVTev4ymxn0t7Z7CNbbFymZJgGWlXo3gzWySTjdmmTATgmaD6jrw==", null, false, "bd5f78c2-8461-4d21-8a81-16ecab4ae17c", false, "bartek" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ac3eaa98-b50e-47e5-9d1c-da0bf9e49755", "7db0b162-e56a-4a63-a8c1-1ea091eeacbb" });
        }
    }
}
