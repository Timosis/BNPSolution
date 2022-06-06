using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BNP.DataAccess.Migrations
{
    public partial class BNPSOL_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileHistory_File_FileId",
                table: "FileHistory");

            migrationBuilder.DropIndex(
                name: "IX_FileHistory_FileId",
                table: "FileHistory");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "227b5679-e7cf-44a1-a2e4-858a36806fc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daf65646-5be1-49c4-bd5e-c31bd2357926");

            migrationBuilder.AddColumn<int>(
                name: "UserFileId",
                table: "FileHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f2532a7-b54c-4661-b65d-902df46d7190", "b8fd0bb3-2bdb-4d51-a529-7e67b8439872", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e39fecc3-74bf-445b-9a3b-cad4ac91267c", "a5730fbb-8b90-4b10-89fe-e15b62e41a07", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_FileHistory_UserFileId",
                table: "FileHistory",
                column: "UserFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileHistory_File_UserFileId",
                table: "FileHistory",
                column: "UserFileId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileHistory_File_UserFileId",
                table: "FileHistory");

            migrationBuilder.DropIndex(
                name: "IX_FileHistory_UserFileId",
                table: "FileHistory");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f2532a7-b54c-4661-b65d-902df46d7190");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e39fecc3-74bf-445b-9a3b-cad4ac91267c");

            migrationBuilder.DropColumn(
                name: "UserFileId",
                table: "FileHistory");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "227b5679-e7cf-44a1-a2e4-858a36806fc5", "16cb9659-0676-4c51-9518-38428a5e5eec", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "daf65646-5be1-49c4-bd5e-c31bd2357926", "5f4e92f8-92f0-4299-9551-988987939998", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_FileHistory_FileId",
                table: "FileHistory",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileHistory_File_FileId",
                table: "FileHistory",
                column: "FileId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
