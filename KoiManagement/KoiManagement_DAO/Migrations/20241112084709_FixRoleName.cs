using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KoiManagement_DAO.Migrations
{
    /// <inheritdoc />
    public partial class FixRoleName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c186574-b2b9-434f-9653-e138e12a6817", null, "Referee", "REFEREE" },
                    { "6c4c0c74-e99b-49ac-a150-429662c85856", null, "Manager", "MANAGER" },
                    { "9f31dece-fb71-4e8e-804a-11a301b75c73", null, "Contestant", "CONTESTANT" },
                    { "eba17ca2-2a62-4282-b49c-471bd48048f0", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c186574-b2b9-434f-9653-e138e12a6817");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4c0c74-e99b-49ac-a150-429662c85856");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f31dece-fb71-4e8e-804a-11a301b75c73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eba17ca2-2a62-4282-b49c-471bd48048f0");

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
    }
}
