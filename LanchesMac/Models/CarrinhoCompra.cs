using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models;
public class CarrinhoCompra
{
    private readonly AppDbContext _context;

    public CarrinhoCompra(AppDbContext context)
    {
        _context = context;
    }

    public string IdCarrinhoCompa { get; set; }
    public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
    public static CarrinhoCompra GetCarrinho(IServiceProvider services)
    {
        //define uma sessão
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        //obtem um serviço do tipo do contexto
        var context = services.GetService<AppDbContext>();

        //obtem ou gera o Id do carrinho
        string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        //atribui o id do carrinho na Sessão
        session.SetString("CarrinhoId", carrinhoId);

        //retorna o carrinho com o contrxto e o Id atribuido ou obtido
        return new CarrinhoCompra(context)
        {
            IdCarrinhoCompa = carrinhoId,
        };
    }
    public void AdicionarAoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(s => s.Lanche.IdLanche == lanche.IdLanche
        && s.IdCarrinhoCompra == IdCarrinhoCompa);

        if (carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem
            {
                IdCarrinhoCompra = IdCarrinhoCompa,
                Lanche = lanche,
                Quaditade = 1
            };
            _context.CarrinhoCompraItems.Add(carrinhoCompraItem);
        }
        else
        {
            carrinhoCompraItem.Quaditade++;
        }
        _context.SaveChanges();
    }
    public int RemoverDoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(s => s.Lanche.IdLanche == lanche.IdLanche
        && s.IdCarrinhoCompra == IdCarrinhoCompa);

        var quantidadeLocal = 0;

        if (carrinhoCompraItem != null)
        {
            carrinhoCompraItem.Quaditade--;
            quantidadeLocal = carrinhoCompraItem.Quaditade;
        }
        else
        {
            _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
        }
        _context.SaveChanges();
        return quantidadeLocal;
    }
    public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
    {
        return CarrinhoCompraItems ??
            (CarrinhoCompraItems =
            _context.CarrinhoCompraItems.Where(c => c.IdCarrinhoCompra == IdCarrinhoCompa)
            .Include(s => s.Lanche)
            .ToList());
    }
    public void LimparCarrinho()
    {
        var carrinhoItens = _context.CarrinhoCompraItems.Where(carrinho => carrinho.IdCarrinhoCompra == IdCarrinhoCompa);

        _context.CarrinhoCompraItems.RemoveRange(carrinhoItens);
        _context.SaveChanges();
    }
    public decimal GetCarrinhoCompraTotal()
    {
        var total = _context.CarrinhoCompraItems.Where(c => c.IdCarrinhoCompra == IdCarrinhoCompa)
            .Select(c => c.Lanche.Preco * c.Quaditade).Sum();

        return total;
    }
}
