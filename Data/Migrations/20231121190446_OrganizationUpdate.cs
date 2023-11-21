using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "contacts",
                newName: "ContactId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birth",
                table: "contacts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_City = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_Street = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_PostalCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "Name", "Adress_City", "Adress_PostalCode", "Adress_Street" },
                values: new object[,]
                {
                    { 101, "Uczelnia wyższa", "WSEI", "Kraków", "31-150", "św. Filipa 17" },
                    { 102, "Przedsiębiorstwo IT", "Comarch", "Kraków", "36-160", "Rozwoju 1/4" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                columns: new[] { "Birth", "Email", "name", "OrganizationId", "Phone" },
                values: new object[] { new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam@wsei.edu.pl", "Adam", 101, "124124234" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                columns: new[] { "Birth", "Email", "name", "OrganizationId", "Phone" },
                values: new object[] { new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam@wsei.edu.pl", "Adam", 102, "124124234" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                columns: new[] { "Birth", "Email", "name", "OrganizationId", "Phone" },
                values: new object[] { new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam@wsei.edu.pl", "Adam", 102, "124124234" });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_Organizations_OrganizationId",
                table: "contacts",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_Organizations_OrganizationId",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "contacts");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "contacts",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birth",
                table: "contacts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    PageNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PublicationYear = table.Column<string>(type: "TEXT", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "ISBN", "PageNumber", "PublicationYear", "Publisher", "Title" },
                values: new object[] { 1, "sssss", "1234567891234", "222", "2002-09-09", "loll", "ssadasdad" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birth", "Email", "name", "Phone" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "asdad@.pl", "adam", "23123123131" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birth", "Email", "name", "Phone" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "asdad@.pl", "ada21123m", "23123123131" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birth", "Email", "name", "Phone" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "asdad@.pl", "a231111dam", "23123123131" });
        }
    }
}
