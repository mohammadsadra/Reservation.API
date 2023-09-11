using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.API.Migrations
{
    /// <inheritdoc />
    public partial class addseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "EmailAddress", "Name", "PhoneNumber", "Role" },
                values: new object[] { new Guid("f340bf05-8262-424a-ad70-577d9c4b8a91"), "Mehran@bazidid.com", "Mehran Ahmadi", "09127959333", 0 });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Guid", "Address", "Name", "UserGuid" },
                values: new object[] { new Guid("6725d8b7-6fe4-4d71-83a7-720f8ba41779"), "Heravi, Mohammadi, p12", "Allame Helli", new Guid("f340bf05-8262-424a-ad70-577d9c4b8a91") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Guid",
                keyValue: new Guid("6725d8b7-6fe4-4d71-83a7-720f8ba41779"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("f340bf05-8262-424a-ad70-577d9c4b8a91"));
        }
    }
}
