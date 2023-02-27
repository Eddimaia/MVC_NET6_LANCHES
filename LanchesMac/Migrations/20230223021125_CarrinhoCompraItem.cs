using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    /// <inheritdoc />
    public partial class CarrinhoCompraItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoCompraItens",
                columns: table => new
                {
                    ID_CARRINHO_COMPRA_ITEM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LancheIdLanche = table.Column<int>(type: "int", nullable: true),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    ID_CARRINHO_COMPRA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompraItens", x => x.ID_CARRINHO_COMPRA_ITEM);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompraItens_Lanches_LancheIdLanche",
                        column: x => x.LancheIdLanche,
                        principalTable: "Lanches",
                        principalColumn: "ID_LANCHE");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItens_LancheIdLanche",
                table: "CarrinhoCompraItens",
                column: "LancheIdLanche");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoCompraItens");
        }
    }
}
