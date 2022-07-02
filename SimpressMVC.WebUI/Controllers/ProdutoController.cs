using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpressMVC.Application.DTOs;
using SimpressMVC.Application.Interfaces;
using SimpressMVC.WebUI.Models;
using System.Threading.Tasks;

namespace SimpressMVC.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        MyViewModel myViewModel = new MyViewModel();

        public ProdutoController(IProdutoService produtoService, ICategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var categoria = await _categoriaService.GetCategoriaAsync();
            var produto = await _produtoService.GetProdutoAsync();

            ViewBag.CategoryId = new SelectList(await _categoriaService.GetCategoriaAsync(), "Id", "Nome");

            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoDTO productDTO)
        {
            var produto = await _produtoService.GetProdutoAsync();

            productDTO.Ativo = true;
            productDTO.Perecivel = true;

            await _produtoService.AddAsync(productDTO);
            return RedirectToAction("Index","Produto");
        }
    }
}
