using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Technicians_TechniciansId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TechniciansId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "TechniciansId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "TechnicalId",
                table: "Appointments",
                newName: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TechnicianId",
                table: "Appointments",
                column: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Technicians_TechnicianId",
                table: "Appointments",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Technicians_TechnicianId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TechnicianId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "TechnicianId",
                table: "Appointments",
                newName: "TechnicalId");

            migrationBuilder.AddColumn<int>(
                name: "TechniciansId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TechniciansId",
                table: "Appointments",
                column: "TechniciansId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Technicians_TechniciansId",
                table: "Appointments",
                column: "TechniciansId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }
    }
}
