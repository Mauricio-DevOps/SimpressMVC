using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpressMVC.Application.DTOs;
using SimpressMVC.Application.Interfaces;
using SimpressMVC.WebUI.Models;
using System.Threading.Tasks;
using SimpressMVC.WebUI.API;
using System.Collections.Generic;
using SimpressMVC.WebUI.API.Response;

namespace SimpressMVC.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;



        //MyViewModel myViewModel = new MyViewModel();

        public ProdutoController(
            IProdutoService produtoService, ICategoriaService categoriaService
            )
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produto = ExecutaApi.ConsultaVerboGet<IEnumerable<ProdutoDTO>>("https://localhost:44320/api/Produto");
            var categoria = ExecutaApi.ConsultaVerboGet<IEnumerable<CategoriaDTO>>("https://localhost:44320/api/Categoria");
            ViewBag.CategoryId = new SelectList(categoria, "Id", "Nome");
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoDTO productDTO)
        {
            productDTO.Ativo = true;
            productDTO.Perecivel = true;
            var resposta = ExecutaApi.ConsultaVerboPost<ProdutoDTO>("https://localhost:44320/api/Produto",productDTO);
            return RedirectToAction("Index","Produto");
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == null) return NotFound();
            var produtoDTO = ExecutaApi.ConsultaVerboGet<ProdutoDTO>("https://localhost:44320/api/Produto/" + Id);
            if (produtoDTO == null) return NotFound();
            var categorias = ExecutaApi.ConsultaVerboGet<IEnumerable<CategoriaDTO>>("https://localhost:44320/api/Categoria");
            ViewBag.CategoryId = new SelectList(categorias, "Id", "Nome");
            ViewBag.Id = produtoDTO.CategoriaId;
            return View(produtoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProdutoDTO productDTO)
        {
            var resposta = ExecutaApi.ConsultaVerboPut<ProdutoDTO>("https://localhost:44320/api/Produto", productDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int Id)
        {
            var resposta = ExecutaApi.ConsultaVerboDelete<ProdutoDTO>("https://localhost:44320/api/Produto/" + Id);
            return RedirectToAction("Index", "Produto");
        }
    }
}
