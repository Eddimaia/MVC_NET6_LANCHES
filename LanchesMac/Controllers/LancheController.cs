using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;
public class LancheController : Controller
{
    private readonly ILancheRepository _lancheRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
    {
        _lancheRepository = lancheRepository;
        _categoriaRepository = categoriaRepository;
    }

    public IActionResult List()
    {
        ViewData["Titutlo"] = "Categoria Atual";
        ViewData["Data"] = DateTime.Now.ToString("dd/MM/yyyy hh:mm");

        var lancheListViewModels = new LancheListViewModel();
        lancheListViewModels.Lanches = _lancheRepository.Lanches;
        //lancheListViewModels.CategoriaAtual = _categoriaRepository.Categorias;

        ViewBag.Total = "Total de Lanches: ";
        ViewBag.TotalLanches = lancheListViewModels.Lanches.Count();

        return View(lancheListViewModels);
    }
}
