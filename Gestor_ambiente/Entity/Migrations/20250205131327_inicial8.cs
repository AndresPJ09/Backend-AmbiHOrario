using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class inicial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Validación",
                table: "Horarios",
                newName: "Validacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Validacion",
                table: "Horarios",
                newName: "Validación");
        }
    }
}
