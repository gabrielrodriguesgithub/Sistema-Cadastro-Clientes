using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCadastroCliente.Migrations
{
    /// <inheritdoc />
    public partial class Ajusteendereconome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereço",
                table: "AspNetUsers",
                newName: "Endereco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "AspNetUsers",
                newName: "Endereço");
        }
    }
}
