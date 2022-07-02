using Microsoft.AspNetCore.Mvc;
using SimpressMVC.Application.Interfaces;
using System.Threading.Tasks;

namespace SimpressMVC.WebUI.Controllers
{
    public class CategoriasController : Controller
    {
        

        private readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.GetCategoriaAsync();

            return View(categorias);
        }
    }
}
