using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BNP.DataAccess.Migrations
{
    public partial class BNPSOL_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileHistory_File_UserFileId",
                table: "FileHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_File",
                table: "File");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "226a0210-f533-4ab6-bb97-675d43801e67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "310679e6-1295-4d19-9047-9053b4ebba73");

            migrationBuilder.RenameTable(
                name: "File",
                newName: "UserFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFile",
                table: "UserFile",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f880d14-17c3-4f0d-b77d-602ffe7c0ed6", "164e0028-cffd-4724-84ae-d14a9f1e557c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db5352b2-cfa5-47a2-b4ea-a3866ce793d5", "ccefb9fc-b732-4e64-aef7-95458fbe5c86", "Visitor", "VISITOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_FileHistory_UserFile_UserFileId",
                table: "FileHistory",
                column: "UserFileId",
                principalTable: "UserFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileHistory_UserFile_UserFileId",
                table: "FileHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFile",
                table: "UserFile");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f880d14-17c3-4f0d-b77d-602ffe7c0ed6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db5352b2-cfa5-47a2-b4ea-a3866ce793d5");

            migrationBuilder.RenameTable(
                name: "UserFile",
                newName: "File");

            migrationBuilder.AddPrimaryKey(
                name: "PK_File",
                table: "File",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "226a0210-f533-4ab6-bb97-675d43801e67", "ae3e5066-7a07-4b30-ab69-d2119d5e26f4", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "310679e6-1295-4d19-9047-9053b4ebba73", "c1b89525-9da8-4c3f-adf2-31889393d547", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_FileHistory_File_UserFileId",
                table: "FileHistory",
                column: "UserFileId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
