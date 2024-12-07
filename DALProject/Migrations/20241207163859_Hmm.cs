using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALProject.Migrations
{
    /// <inheritdoc />
    public partial class Hmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_TicketId",
                table: "CartItems",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Tickets_TicketId",
                table: "CartItems",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Tickets_TicketId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_TicketId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "CartItems");
        }
    }
}
