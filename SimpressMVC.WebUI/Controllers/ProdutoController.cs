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

        [HttpGet()]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == null) return NotFound();
            var produtoDTO = await _produtoService.GetByIdAsync(Id);

            if (produtoDTO == null) return NotFound();

            var categorias = await _categoriaService.GetCategoriaAsync();

            ViewBag.CategoryId = new SelectList(await _categoriaService.GetCategoriaAsync(), "Id", "Nome");
            ViewBag.Id = produtoDTO.CategoriaId;
            //ViewBag.CategoriaId = new SelectList(categorias, "Id", "Name", produtoDTO.CategoriaId);

            return View(produtoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProdutoDTO productDTO)
        {
            await _produtoService.UpdateAsync(productDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int Id)
        {
            await _produtoService.RemoveAsync(Id);

            return RedirectToAction("Index", "Produto");
        }
    }
}
