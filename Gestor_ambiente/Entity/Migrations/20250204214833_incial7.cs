using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class incial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "est_ideal_evalu",
                table: "ConsolidadoAmbientes");

            migrationBuilder.RenameColumn(
                name: "mes",
                table: "Periodos",
                newName: "nombre");

            migrationBuilder.AddColumn<int>(
                name: "ano",
                table: "Periodos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_fin",
                table: "Periodos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_inicio",
                table: "Periodos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AmbienteId",
                table: "ConsolidadoAmbientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidadoAmbientes_AmbienteId",
                table: "ConsolidadoAmbientes",
                column: "AmbienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidadoAmbientes_Ambientes_AmbienteId",
                table: "ConsolidadoAmbientes",
                column: "AmbienteId",
                principalTable: "Ambientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidadoAmbientes_Ambientes_AmbienteId",
                table: "ConsolidadoAmbientes");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidadoAmbientes_AmbienteId",
                table: "ConsolidadoAmbientes");

            migrationBuilder.DropColumn(
                name: "ano",
                table: "Periodos");

            migrationBuilder.DropColumn(
                name: "fecha_fin",
                table: "Periodos");

            migrationBuilder.DropColumn(
                name: "fecha_inicio",
                table: "Periodos");

            migrationBuilder.DropColumn(
                name: "AmbienteId",
                table: "ConsolidadoAmbientes");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Periodos",
                newName: "mes");

            migrationBuilder.AddColumn<string>(
                name: "est_ideal_evalu",
                table: "ConsolidadoAmbientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
