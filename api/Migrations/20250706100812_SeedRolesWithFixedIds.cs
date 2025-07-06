using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesWithFixedIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96826f82-9010-43aa-b750-01012767b543");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd542817-6315-4ef8-bb4f-9dca91c736ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", null, "Admin", "ADMIN" },
                    { "F6F1A3F6-76C1-4A1F-B56C-BFFDB62D78C5", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F6F1A3F6-76C1-4A1F-B56C-BFFDB62D78C5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96826f82-9010-43aa-b750-01012767b543", null, "Admin", "ADMIN" },
                    { "cd542817-6315-4ef8-bb4f-9dca91c736ce", null, "User", "USER" }
                });
        }
    }
}
