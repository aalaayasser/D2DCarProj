using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALProject.Migrations
{
    /// <inheritdoc />
    public partial class tt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelPart");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ModelPart",
                columns: table => new
                {
                    ModelsId = table.Column<int>(type: "int", nullable: false),
                    PartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelPart", x => new { x.ModelsId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_ModelPart_Models_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelPart_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelPart_PartsId",
                table: "ModelPart",
                column: "PartsId");
        }
    }
}
