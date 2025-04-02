using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication9.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoa = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: true),
                    NumeroNotaFiscal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.IdCompra);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.IdEstadoCivil);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.IdPessoa);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
