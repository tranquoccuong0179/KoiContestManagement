using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiManagement_DAO.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Kois_KoiId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Results_KoiId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "KoiId",
                table: "Results");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KoiId",
                table: "Results",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KoiId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResultId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Kois_KoiId",
                        column: x => x.KoiId,
                        principalTable: "Kois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Achievements_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_KoiId",
                table: "Results",
                column: "KoiId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_KoiId",
                table: "Achievements",
                column: "KoiId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_ResultId",
                table: "Achievements",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Kois_KoiId",
                table: "Results",
                column: "KoiId",
                principalTable: "Kois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
