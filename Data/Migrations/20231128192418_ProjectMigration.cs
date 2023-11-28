using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjectMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0977e680-6277-4828-a9a4-6ba3cb15d4ae", "39bd566e-1be8-4642-9f06-5598e6fae20d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0977e680-6277-4828-a9a4-6ba3cb15d4ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39bd566e-1be8-4642-9f06-5598e6fae20d");

            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "books",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RentalName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    RentingPerson_Name = table.Column<string>(type: "TEXT", nullable: false),
                    RentingPerson_Surname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac3eaa98-b50e-47e5-9d1c-da0bf9e49755", "ac3eaa98-b50e-47e5-9d1c-da0bf9e49755", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7db0b162-e56a-4a63-a8c1-1ea091eeacbb", 0, "b33f5e42-8592-466e-b3e4-c0261c1546fe", "bartek@wsei.pl", true, false, null, "BARTEK@WSEI.PL", "BARTEK", "AQAAAAEAACcQAAAAEOBNxXm4RxvqLUKVTev4ymxn0t7Z7CNbbFymZJgGWlXo3gzWySTjdmmTATgmaD6jrw==", null, false, "bd5f78c2-8461-4d21-8a81-16ecab4ae17c", false, "bartek" });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "Description", "RentalName", "RentingPerson_Name", "RentingPerson_Surname" },
                values: new object[,]
                {
                    { 1, "Wypożyczalnia publiczna", "Biblioteka Miejska", "Anna", "Nowak" },
                    { 2, "Sklep z książkami", "Księgarnia XYZ", "Jan", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ac3eaa98-b50e-47e5-9d1c-da0bf9e49755", "7db0b162-e56a-4a63-a8c1-1ea091eeacbb" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "ISBN", "PageNumber", "PublicationYear", "Publisher", "RentalId", "Title" },
                values: new object[,]
                {
                    { 1, "John Smith", "9780123456789", "300", "2022", "Tech Books", 1, "C# Programming" },
                    { 2, "Emily Johnson", "9789876543210", "250", "2021", "Coding Press", 2, "Introduction to ASP.NET Core" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_RentalId",
                table: "books",
                column: "RentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_Rentals_RentalId",
                table: "books",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_Rentals_RentalId",
                table: "books");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_books_RentalId",
                table: "books");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ac3eaa98-b50e-47e5-9d1c-da0bf9e49755", "7db0b162-e56a-4a63-a8c1-1ea091eeacbb" });

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac3eaa98-b50e-47e5-9d1c-da0bf9e49755");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7db0b162-e56a-4a63-a8c1-1ea091eeacbb");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0977e680-6277-4828-a9a4-6ba3cb15d4ae", "0977e680-6277-4828-a9a4-6ba3cb15d4ae", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "39bd566e-1be8-4642-9f06-5598e6fae20d", 0, "b9584146-ece5-480a-959e-dadf5a3cf299", "bartek@wsei.pl", true, false, null, "BARTEK@WSEI.PL", "BARTEK", "AQAAAAEAACcQAAAAEHqc0ZS2dqqUqmtv6joJ7f44HfB9UpJoobKCOpY0w+7W7ALfW2SVPRxJnYTXxdF1uw==", null, false, "59bdbf27-c700-4b80-8a16-1741baece2b5", false, "bartek" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0977e680-6277-4828-a9a4-6ba3cb15d4ae", "39bd566e-1be8-4642-9f06-5598e6fae20d" });
        }
    }
}
