using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamoroApp.Migrations
{
    /// <inheritdoc />
    public partial class senhaHasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "SenhaHas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenhaHas",
                table: "Usuarios",
                newName: "Senha");
        }
    }
}
