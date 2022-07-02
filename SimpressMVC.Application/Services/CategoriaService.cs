using AutoMapper;
using SimpressMVC.Application.DTOs;
using SimpressMVC.Application.Interfaces;
using SimpressMVC.Domain.Entities;
using SimpressMVC.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpressMVC.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaProdutoRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaService(ICategoriaProdutoRepository categoriaProdutoRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaProdutoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategoriaAsync()
        {
            var categoriaEntity = await _categoriaRepository.GetCategoriasAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriaEntity);
        }

        public async Task<CategoriaDTO> GetByIdAsync(int? id)
        {
            var categoriaEntity = await _categoriaRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoriaEntity);
        }

        public async Task AddAsync(CategoriaDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<CategoriaProduto>(categoriaDTO);
            await _categoriaRepository.CreateAsync(categoriaEntity);
        }

        public async Task UpdateAsync(CategoriaDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<CategoriaProduto>(categoriaDTO);
            await _categoriaRepository.UpdateAsync(categoriaEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var categoriaEntity = _categoriaRepository.GetByIdAsync(id).Result;
            await _categoriaRepository.RemoveAsync(categoriaEntity);
        }
    }
}
