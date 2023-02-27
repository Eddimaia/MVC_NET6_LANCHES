using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;
public class CarrinhoCompraController : Controller
{
    private readonly ILancheRepository _lancheRepository;
    private readonly CarrinhoCompra _carrinhoCompra;
    public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
    {
        _lancheRepository = lancheRepository;
        _carrinhoCompra = carrinhoCompra;
    }
    public IActionResult Index()
    {
        var itens = _carrinhoCompra.GetCarrinhoCompraItems();

        _carrinhoCompra.CarrinhoCompraItems = itens;

        var carrinhoCompraVM = new CarrinhoCompraViewModel
        {
            CarrinhoCompra = _carrinhoCompra,
            CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
        };

        return View(carrinhoCompraVM);
    }
    public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int idLanche)
    {
        var lacheSelecionado = _lancheRepository.Lanches.FirstOrDefault(l => l.IdLanche == idLanche);

        if (lacheSelecionado != null)
        {
            _carrinhoCompra.AdicionarAoCarrinho(lacheSelecionado);
        }

        return RedirectToAction("Index");
    }
    public RedirectToActionResult RemoverItemNoCarrinhoCompra(int idLanche)
    {
        var lacheSelecionado = _lancheRepository.Lanches.FirstOrDefault(l => l.IdLanche == idLanche);

        if (lacheSelecionado != null)
        {
            _carrinhoCompra.RemoverDoCarrinho(lacheSelecionado);
        }

        return RedirectToAction("Index");
    }
}
