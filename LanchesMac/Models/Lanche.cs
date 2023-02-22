using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models;
[Table("Lanches")]
public class Lanche
{
    [Key]
    [Column("ID_LANCHE")]
    public int IdLanche { get; set; }
    [Required(ErrorMessage = "O {0} do lanche deve ser informado.")]
    [Display(Name = "Nome do Lanche")]
    [StringLength(80, MinimumLength = 10, ErrorMessage = "Tamanho mínimo")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A descrição deve ser informada.")]
    [Display(Name = "Descrição do Lanche")]
    [StringLength(200, MinimumLength = 20, ErrorMessage = "Descrição deve conter no mínimo {2} e no máximo {1} caracteres.")]
    public string DescricaoCurta { get; set; }
    [Required(ErrorMessage = "A descrição deve ser informada.")]
    [Display(Name = "Descrição do Lanche")]
    [StringLength(200, MinimumLength = 20, ErrorMessage = "Descrição deve conter no mínimo {2} e no máximo {1} caracteres.")]
    public string DescricaoDetalhada { get; set; }
    [Required(ErrorMessage = "Informe o preço do lanche")]
    [Display(Name = "Preço")]
    [Column(TypeName = "dacimal(10,2)")]
    [Range(1, 999.99, ErrorMessage = "O preço do lanche deve estar ente {1} e {2}")]
    public decimal Preco { get; set; }
    [Display(Name = "Caminho Imagem Normal")]
    [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
    public string ImagemUrl { get; set; }

    [Display(Name = "Caminho Imagem Miniatura")]
    [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
    public string ImagemThumbnailUrl { get; set; }
    [Display(Name = "Preferido?")]
    public bool IsLanchePreferido { get; set; }
    [Display(Name = "Estoque?")]
    public bool EmEstoque { get; set; }

    public int IdCategoria { get; set; }
    public virtual Categoria Categoria { get; set; }
}