using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models;

[Table("Categorias")]
public class Categoria
{
    [Key]
    [Column("ID_CATEGORIA")]
    public int IdCategoria { get; set; }
    [Required(ErrorMessage = "Informe o nome da categoria")]
    [Display(Name = "Nome")]
    [Column("CATEGORIA_NOME")]
    [StringLength(100, ErrorMessage = "O tamanho máximo é de {0} caracteres")]
    public string CategoriaNome { get; set; }
    [Required(ErrorMessage = "Informe a descrição da categoria")]
    [Display(Name = "Descrição")]
    [Column("DESCRICAO")]
    [StringLength(200, ErrorMessage = "O tamanho máximo é de {0} caracteres")]
    public string Descricao { get; set; } 
    public List<Lanche> Lanches { get; set; }
}
