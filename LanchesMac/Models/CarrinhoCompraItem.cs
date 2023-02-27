
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models;
[Table("CarrinhoCompraItens")]
public class CarrinhoCompraItem
{
    [Column("ID_CARRINHO_COMPRA_ITEM")]
    public int CarrinhoCompraItemId { get; set; }
    [Column("ID_LANCHE")]
    public Lanche Lanche { get; set; }
    [Column("QUANTIDADE")]
    public int Quaditade { get; set; }
    [Column("ID_CARRINHO_COMPRA")]
    [StringLength(200)]
    public string IdCarrinhoCompra { get; set; }
}
