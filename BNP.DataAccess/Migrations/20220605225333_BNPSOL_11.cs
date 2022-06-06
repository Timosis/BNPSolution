using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BNP.DataAccess.Migrations
{
    public partial class BNPSOL_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f2532a7-b54c-4661-b65d-902df46d7190");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e39fecc3-74bf-445b-9a3b-cad4ac91267c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "226a0210-f533-4ab6-bb97-675d43801e67", "ae3e5066-7a07-4b30-ab69-d2119d5e26f4", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "310679e6-1295-4d19-9047-9053b4ebba73", "c1b89525-9da8-4c3f-adf2-31889393d547", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "226a0210-f533-4ab6-bb97-675d43801e67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "310679e6-1295-4d19-9047-9053b4ebba73");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f2532a7-b54c-4661-b65d-902df46d7190", "b8fd0bb3-2bdb-4d51-a529-7e67b8439872", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e39fecc3-74bf-445b-9a3b-cad4ac91267c", "a5730fbb-8b90-4b10-89fe-e15b62e41a07", "Administrator", "ADMINISTRATOR" });
        }
    }
}
