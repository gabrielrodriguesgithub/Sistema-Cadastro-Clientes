using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCadastroCliente.Migrations
{
    /// <inheritdoc />
    public partial class Adiçãofoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "AspNetUsers",
                newName: "FotoPath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FotoPath",
                table: "AspNetUsers",
                newName: "Foto");
        }
    }
}
