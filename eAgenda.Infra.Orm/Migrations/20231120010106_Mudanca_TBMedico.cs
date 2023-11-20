using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAgendaMedica.Infra.Orm.Migrations
{
    public partial class Mudanca_TBMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBHoraOcupadas_TBMedico_MedicoId",
                table: "TBHoraOcupadas");

            migrationBuilder.AddForeignKey(
                name: "FK_TBHoraOcupadas_TBMedico_MedicoId",
                table: "TBHoraOcupadas",
                column: "MedicoId",
                principalTable: "TBMedico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBHoraOcupadas_TBMedico_MedicoId",
                table: "TBHoraOcupadas");

            migrationBuilder.AddForeignKey(
                name: "FK_TBHoraOcupadas_TBMedico_MedicoId",
                table: "TBHoraOcupadas",
                column: "MedicoId",
                principalTable: "TBMedico",
                principalColumn: "Id");
        }
    }
}
