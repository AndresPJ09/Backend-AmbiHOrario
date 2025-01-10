using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class inicial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_Users_userId",
                table: "Fichas");

            migrationBuilder.DropColumn(
                name: "GestorId",
                table: "Fichas");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Fichas",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Fichas_userId",
                table: "Fichas",
                newName: "IX_Fichas_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_Users_UserId",
                table: "Fichas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_Users_UserId",
                table: "Fichas");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Fichas",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Fichas_UserId",
                table: "Fichas",
                newName: "IX_Fichas_userId");

            migrationBuilder.AddColumn<int>(
                name: "GestorId",
                table: "Fichas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_Users_userId",
                table: "Fichas",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
