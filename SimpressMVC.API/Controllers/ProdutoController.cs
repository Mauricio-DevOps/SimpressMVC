using Microsoft.AspNetCore.Mvc;
using SimpressMVC.Application.DTOs;
using SimpressMVC.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpressMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> Get()
        {
            var categorias = await _produtoService.GetProdutoAsync();
            return categorias;
        }

        [HttpGet("{id:int}", Name = "GetProduto")]
        public async Task<ProdutoDTO> Get(int id)
        {
            var categoria = await _produtoService.GetByIdAsync(id);
            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
                return BadRequest("Valores Invalidos");

            await _produtoService.AddAsync(produtoDTO);

            return new CreatedAtRouteResult("GetProduto", new { id = produtoDTO.Id },
                produtoDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
                return BadRequest();

            if (produtoDTO == null)
                return BadRequest();

            await _produtoService.UpdateAsync(produtoDTO);

            return Ok(produtoDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var categoria = await _produtoService.GetByIdAsync(id);
            if (categoria == null)
                return NotFound("Categoria não encontrada");

            await _produtoService.RemoveAsync(id);

            return Ok(categoria);
        }
    }
}
