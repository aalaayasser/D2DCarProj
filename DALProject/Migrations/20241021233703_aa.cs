using Microsoft.EntityFrameworkCore.Migrations;

namespace DALProject.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b0d60b7-2256-449b-a9aa-7f52734c2d9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f23e21b-953e-466d-b145-054c34daf591");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb8a79c1-0d0a-45af-987f-0aba80374e4d");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Technicians",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3cde313-d46a-4658-8a39-56a949d3066d", "2b0ab6c9-978b-483e-b29b-c18def602d20", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7f5635f-f094-46b2-aa47-af8cd1e4f981", "e03ecf4b-7eed-41be-9104-0c3ea97bb967", "technincian", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb2b3cfb-c243-400b-a781-fc04f656930b", "30f616e6-76ad-40a4-829a-9139e0550670", "csutomer", "technincian" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb2b3cfb-c243-400b-a781-fc04f656930b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3cde313-d46a-4658-8a39-56a949d3066d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7f5635f-f094-46b2-aa47-af8cd1e4f981");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Technicians");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Drivers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b0d60b7-2256-449b-a9aa-7f52734c2d9a", "20a4f2b2-e8a1-491f-bd9a-beb13d2918c1", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb8a79c1-0d0a-45af-987f-0aba80374e4d", "ee9c9705-7051-4eb2-8185-c11a119c1253", "technincian", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f23e21b-953e-466d-b145-054c34daf591", "79c27e85-80a9-4e77-817c-3a472025261c", "csutomer", "technincian" });
        }
    }
}
