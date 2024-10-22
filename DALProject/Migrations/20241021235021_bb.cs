using Microsoft.EntityFrameworkCore.Migrations;

namespace DALProject.Migrations
{
    public partial class bb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e8a98fa-209a-4ff4-82a4-ece1977e7844", "aa71b700-148d-467d-bedd-af01c6ec9d0c", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "463e205e-4dbb-408d-976c-98fd49427bcb", "5c46c72e-e391-41e9-9990-08ce8ccd4c85", "technincian", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bab5116c-5295-427e-86ed-609b59595cdd", "f542ccd0-4726-41ec-830b-dde3e37a4b37", "csutomer", "technincian" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "463e205e-4dbb-408d-976c-98fd49427bcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e8a98fa-209a-4ff4-82a4-ece1977e7844");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5116c-5295-427e-86ed-609b59595cdd");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

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
    }
}
