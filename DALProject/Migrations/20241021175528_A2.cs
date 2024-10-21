using Microsoft.EntityFrameworkCore.Migrations;

namespace DALProject.Migrations
{
    public partial class A2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
