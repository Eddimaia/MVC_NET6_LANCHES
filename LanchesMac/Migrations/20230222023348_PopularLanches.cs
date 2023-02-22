using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    /// <inheritdoc />
    public partial class PopularLanches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO LANCHES ( 
                                    NOME
                                    ,  DESCRICAO_CURTA
                                    ,  DESCRICAO_DETALHADA
                                    ,  PRECO
                                    ,  IMAGEM_URL
                                    ,  IMAGEM_THUMB
                                    ,  PREFERIDO
                                    ,  ESTOQUE
                                    ,  ID_CATEGORIA)
                                        VALUES('Boladão', 'Hamburguer do tipo X-Salada', 'Hamburguer do tipo X-Salada', 10.99, NULL, NULL, 0, 1, 1)");
            migrationBuilder.Sql(@"INSERT INTO LANCHES ( 
                                    NOME
                                    ,  DESCRICAO_CURTA
                                    ,  DESCRICAO_DETALHADA
                                    ,  PRECO
                                    ,  IMAGEM_URL
                                    ,  IMAGEM_THUMB
                                    ,  PREFERIDO
                                    ,  ESTOQUE
                                    ,  ID_CATEGORIA)
                                        VALUES('Maneirão', 'Hamburguer do tipo X-Salada Vegano', 'Hamburguer do tipo X-Salada Vegano', 11.99, NULL, NULL, 0, 1, 2)");
            migrationBuilder.Sql(@"INSERT INTO LANCHES ( 
                                    NOME
                                    ,  DESCRICAO_CURTA
                                    ,  DESCRICAO_DETALHADA
                                    ,  PRECO
                                    ,  IMAGEM_URL
                                    ,  IMAGEM_THUMB
                                    ,  PREFERIDO
                                    ,  ESTOQUE
                                    ,  ID_CATEGORIA)
                                        VALUES('O Melhor', 'Hamburguer do tipo X-Burguer', 'Hamburguer do tipo X-Burguer', 9.99, NULL, NULL, 0, 1, 1)");
            migrationBuilder.Sql(@"INSERT INTO LANCHES ( 
                                    NOME
                                    ,  DESCRICAO_CURTA
                                    ,  DESCRICAO_DETALHADA
                                    ,  PRECO
                                    ,  IMAGEM_URL
                                    ,  IMAGEM_THUMB
                                    ,  PREFERIDO
                                    ,  ESTOQUE
                                    ,  ID_CATEGORIA)
                                        VALUES('Sem Erro', 'Hamburguer do tipo X-Burguer com queijo', 'Hamburguer do tipo X-Burguer com queijo, cebola e picles de pepino', 10.99, NULL, NULL, 0, 1, 1)");
            migrationBuilder.Sql(@"INSERT INTO LANCHES ( 
                                    NOME
                                    ,  DESCRICAO_CURTA
                                    ,  DESCRICAO_DETALHADA
                                    ,  PRECO
                                    ,  IMAGEM_URL
                                    ,  IMAGEM_THUMB
                                    ,  PREFERIDO
                                    ,  ESTOQUE
                                    ,  ID_CATEGORIA)
                                        VALUES('De Itália', 'Pizza Marguerita', 'Pizza Marguerita a moda italiana', 27.00, NULL, NULL, 1, 1, 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM LANCHES");
        }
    }
}
