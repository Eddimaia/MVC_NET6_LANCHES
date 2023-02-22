using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    ID_CATEGORIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORIA_NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.ID_CATEGORIA);
                });

            migrationBuilder.CreateTable(
                name: "Lanches",
                columns: table => new
                {
                    ID_LANCHE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DESCRICAO_CURTA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO_DETALHADA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IMAGEM_URL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IMAGEM_THUMB = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PREFERIDO = table.Column<bool>(type: "bit", nullable: false),
                    ESTOQUE = table.Column<bool>(type: "bit", nullable: false),
                    ID_CATEGORIA = table.Column<int>(type: "int", nullable: false),
                    CategoriaIdCategoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanches", x => x.ID_LANCHE);
                    table.ForeignKey(
                        name: "FK_Lanches_Categorias_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "ID_CATEGORIA");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lanches_CategoriaIdCategoria",
                table: "Lanches",
                column: "CategoriaIdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lanches");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
