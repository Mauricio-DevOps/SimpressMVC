using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpressMVC.Application.DTOs;
using SimpressMVC.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpressMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaDTO>> Get()
        {
            var categorias = await _categoriaService.GetCategoriaAsync();
            return categorias;
        }

        [HttpGet("{id:int}", Name = "GetCategoria")]
        public async Task<CategoriaDTO> Get(int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                return BadRequest("Valores Invalidos");

            await _categoriaService.AddAsync(categoriaDTO);

            return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDTO.Id },
                categoriaDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id,[FromBody] CategoriaDTO categoriaDTO)
        {
            if (id != categoriaDTO.Id)
                return BadRequest();

            if (categoriaDTO == null)
                return BadRequest();

            await _categoriaService.UpdateAsync(categoriaDTO);

            return Ok(categoriaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null)
                return NotFound("Categoria não encontrada");

            await _categoriaService.RemoveAsync(id);

            return Ok(categoria);
        }

    }
}
