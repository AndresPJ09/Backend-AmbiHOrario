using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class inicial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_Ambientes_AmbienteId",
                table: "Fichas");

            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_Users_UserId",
                table: "Fichas");

            migrationBuilder.DropIndex(
                name: "IX_Fichas_AmbienteId",
                table: "Fichas");

            migrationBuilder.DropIndex(
                name: "IX_Fichas_UserId",
                table: "Fichas");

            migrationBuilder.DropColumn(
                name: "AmbienteId",
                table: "Fichas");

            migrationBuilder.DropColumn(
                name: "Estado_ideal_evalu_rap",
                table: "Fichas");

            migrationBuilder.DropColumn(
                name: "Estado_RAP",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "Result_aprendizaje",
                table: "Actividades");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Fichas",
                newName: "Cupo");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Competencias",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "Cupo",
                table: "Ambientes",
                newName: "Capacidad");

            migrationBuilder.AddColumn<int>(
                name: "AmbienteId",
                table: "Horarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_inicio",
                table: "Horarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PeriodoId",
                table: "Horarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Horarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Periodos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "raps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompetenciaId = table.Column<int>(type: "int", nullable: false),
                    estado_ideal_evaluacion_rap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_raps_Competencias_CompetenciaId",
                        column: x => x.CompetenciaId,
                        principalTable: "Competencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_AmbienteId",
                table: "Horarios",
                column: "AmbienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_PeriodoId",
                table: "Horarios",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_UserId",
                table: "Horarios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_raps_CompetenciaId",
                table: "raps",
                column: "CompetenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Ambientes_AmbienteId",
                table: "Horarios",
                column: "AmbienteId",
                principalTable: "Ambientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Periodos_PeriodoId",
                table: "Horarios",
                column: "PeriodoId",
                principalTable: "Periodos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Users_UserId",
                table: "Horarios",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Ambientes_AmbienteId",
                table: "Horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Periodos_PeriodoId",
                table: "Horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Users_UserId",
                table: "Horarios");

            migrationBuilder.DropTable(
                name: "Periodos");

            migrationBuilder.DropTable(
                name: "raps");

            migrationBuilder.DropIndex(
                name: "IX_Horarios_AmbienteId",
                table: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_Horarios_PeriodoId",
                table: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_Horarios_UserId",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "AmbienteId",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "Fecha_inicio",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "PeriodoId",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Horarios");

            migrationBuilder.RenameColumn(
                name: "Cupo",
                table: "Fichas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Competencias",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Capacidad",
                table: "Ambientes",
                newName: "Cupo");

            migrationBuilder.AddColumn<int>(
                name: "AmbienteId",
                table: "Fichas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Estado_ideal_evalu_rap",
                table: "Fichas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado_RAP",
                table: "Actividades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Result_aprendizaje",
                table: "Actividades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_AmbienteId",
                table: "Fichas",
                column: "AmbienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_UserId",
                table: "Fichas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_Ambientes_AmbienteId",
                table: "Fichas",
                column: "AmbienteId",
                principalTable: "Ambientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_Users_UserId",
                table: "Fichas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
