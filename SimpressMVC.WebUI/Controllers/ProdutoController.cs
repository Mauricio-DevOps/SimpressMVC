using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpressMVC.Application.DTOs;
using SimpressMVC.Application.Interfaces;
using SimpressMVC.WebUI.API;
using SimpressMVC.WebUI.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpressMVC.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;


        public ProdutoController(
            IProdutoService produtoService, ICategoriaService categoriaService
            )
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }
        public static bool Erro=false;
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produto = ExecutaApi.ConsultaVerboGet<IEnumerable<ProdutoResponse>>("https://localhost:44320/api/Produto");
            var categoria = ExecutaApi.ConsultaVerboGet<IEnumerable<CategoriaResponse>>("https://localhost:44320/api/Categoria");
            ViewBag.CategoryId = new SelectList(categoria, "Id", "Nome");
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoResponse productDTO)
        {
            productDTO.Ativo = true;
            productDTO.Perecivel = true;

            if(productDTO.Nome!=null && productDTO.Descricao != null && productDTO.CategoriaId != null)
            {
                var resposta = ExecutaApi.ConsultaVerboPost<ProdutoResponse>("https://localhost:44320/api/Produto", productDTO);
                Erro = false;
            }
            else
            {
                Erro = true;
            }

            return RedirectToAction("Index", "Produto");
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == null) return NotFound();
            var produtoDTO = ExecutaApi.ConsultaVerboGet<ProdutoResponse>("https://localhost:44320/api/Produto/" + Id);
            if (produtoDTO == null) return NotFound();
            var categorias = ExecutaApi.ConsultaVerboGet<IEnumerable<CategoriaResponse>>("https://localhost:44320/api/Categoria");
            ViewBag.CategoryId = new SelectList(categorias, "Id", "Nome");
            ViewBag.Id = produtoDTO.CategoriaId;
            return View(produtoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProdutoResponse productDTO)
        {
            var resposta = ExecutaApi.ConsultaVerboPut<ProdutoResponse>("https://localhost:44320/api/Produto", productDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int Id)
        {
            var resposta = ExecutaApi.ConsultaVerboDelete<ProdutoResponse>("https://localhost:44320/api/Produto/" + Id);
            return RedirectToAction("Index", "Produto");
        }
    }
}
