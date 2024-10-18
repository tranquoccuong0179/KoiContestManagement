using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KoiManagement_DAO.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "494893fd-8ca2-4e83-976c-9e4eeb01970e", null, "Constestant", "CONSTESTANT" },
                    { "54b67350-2edd-4c73-90ab-f785c2c93c79", null, "Admin", "ADMIN" },
                    { "81cd559a-76b5-4f15-96ef-2b6bca5737ad", null, "Manager", "MANAGER" },
                    { "ac435c21-2bef-4dc6-8fe5-6f24a5ddcd69", null, "Referee", "REFEREE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "494893fd-8ca2-4e83-976c-9e4eeb01970e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b67350-2edd-4c73-90ab-f785c2c93c79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81cd559a-76b5-4f15-96ef-2b6bca5737ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac435c21-2bef-4dc6-8fe5-6f24a5ddcd69");
        }
    }
}
