using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALProject.Migrations
{
    /// <inheritdoc />
    public partial class tttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Models_ModelId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_ModelId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Parts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ModelId",
                table: "Parts",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Models_ModelId",
                table: "Parts",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
