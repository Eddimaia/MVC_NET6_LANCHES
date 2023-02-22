using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO CATEGORIAS(CATEGORIA_NOME, DESCRICAO)
                                    VALUES('Normal', 'Lanches feitos com ingredientes normais')");

            migrationBuilder.Sql(@"INSERT INTO CATEGORIAS(CATEGORIA_NOME, DESCRICAO)
                                    VALUES('Vegano', 'Lanches feitos com ingredientes veganos')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CATEGORIAS");
        }
    }
}
