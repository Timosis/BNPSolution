using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BNP.DataAccess.Migrations
{
    public partial class BNPSOL_13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f880d14-17c3-4f0d-b77d-602ffe7c0ed6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db5352b2-cfa5-47a2-b4ea-a3866ce793d5");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "FileHistory");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b868fd6b-d9a0-4f7c-a7d9-7c6b2ed2e011", "b5c85ac1-e998-4052-83ae-c28c37a3bcab", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8d2a953-aa57-4836-9314-bc73bc802f13", "79df2583-0128-4230-927a-ab4c1f2c49a3", "Visitor", "VISITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b868fd6b-d9a0-4f7c-a7d9-7c6b2ed2e011");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8d2a953-aa57-4836-9314-bc73bc802f13");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "FileHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f880d14-17c3-4f0d-b77d-602ffe7c0ed6", "164e0028-cffd-4724-84ae-d14a9f1e557c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db5352b2-cfa5-47a2-b4ea-a3866ce793d5", "ccefb9fc-b732-4e64-aef7-95458fbe5c86", "Visitor", "VISITOR" });
        }
    }
}
