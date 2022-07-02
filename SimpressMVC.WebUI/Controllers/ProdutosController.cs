using Microsoft.AspNetCore.Mvc;
using SimpressMVC.Application.Interfaces;
using System.Threading.Tasks;


namespace SimpressMVC.WebUI.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produto = await _produtoService.GetProdutoAsync();
            return View(produto);
        }
    }
}
