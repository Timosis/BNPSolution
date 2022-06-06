using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BNP.DataAccess.Migrations
{
    public partial class BNPSOL_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52706338-40e2-4cd9-9cfa-562916c20139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0149225-f591-42e2-99a9-6b404bc5c48b");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "File");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "227b5679-e7cf-44a1-a2e4-858a36806fc5", "16cb9659-0676-4c51-9518-38428a5e5eec", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "daf65646-5be1-49c4-bd5e-c31bd2357926", "5f4e92f8-92f0-4299-9551-988987939998", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "227b5679-e7cf-44a1-a2e4-858a36806fc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daf65646-5be1-49c4-bd5e-c31bd2357926");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "File",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52706338-40e2-4cd9-9cfa-562916c20139", "13d8231c-b6b9-493a-83af-603968f46530", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0149225-f591-42e2-99a9-6b404bc5c48b", "f4db8a0d-25e4-4ac0-a96d-460f8b2bb5ac", "Administrator", "ADMINISTRATOR" });
        }
    }
}
