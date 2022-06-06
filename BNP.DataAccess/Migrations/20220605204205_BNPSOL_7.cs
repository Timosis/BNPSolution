using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BNP.DataAccess.Migrations
{
    public partial class BNPSOL_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3628eed-ab83-4038-91a6-49bb06eb363a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6668f20-14b9-4618-a591-245921236d36");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FileHistory",
                newName: "Type");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52706338-40e2-4cd9-9cfa-562916c20139", "13d8231c-b6b9-493a-83af-603968f46530", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0149225-f591-42e2-99a9-6b404bc5c48b", "f4db8a0d-25e4-4ac0-a96d-460f8b2bb5ac", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52706338-40e2-4cd9-9cfa-562916c20139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0149225-f591-42e2-99a9-6b404bc5c48b");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "FileHistory",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3628eed-ab83-4038-91a6-49bb06eb363a", "60ab52a1-f8f1-41e4-bb2c-53c8b16c094e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6668f20-14b9-4618-a591-245921236d36", "db0899c2-5859-4393-bfa7-1c252b672364", "Visitor", "VISITOR" });
        }
    }
}
