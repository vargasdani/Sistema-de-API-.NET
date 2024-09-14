using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class VinculoPlantacaoClima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClimaId",
                table: "Plantacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plantacoes_ClimaId",
                table: "Plantacoes",
                column: "ClimaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantacoes_Climas_ClimaId",
                table: "Plantacoes",
                column: "ClimaId",
                principalTable: "Climas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantacoes_Climas_ClimaId",
                table: "Plantacoes");

            migrationBuilder.DropIndex(
                name: "IX_Plantacoes_ClimaId",
                table: "Plantacoes");

            migrationBuilder.DropColumn(
                name: "ClimaId",
                table: "Plantacoes");
        }
    }
}
