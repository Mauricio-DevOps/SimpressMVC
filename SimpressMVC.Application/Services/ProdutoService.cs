using AutoMapper;
using SimpressMVC.Application.DTOs;
using SimpressMVC.Application.Interfaces;
using SimpressMVC.Domain.Entities;
using SimpressMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpressMVC.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;
        private ICategoriaProdutoRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, ICategoriaProdutoRepository categoriaProdutoRepository)
        {
            _produtoRepository = produtoRepository ??
                throw new ArgumentNullException(nameof(produtoRepository));
            _categoriaRepository = categoriaProdutoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutoAsync()
        {
            var productosEntity = await _produtoRepository.GetProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(productosEntity);
        }

        public async Task<ProdutoDTO> GetByIdAsync(int? id)
        {
            var produtoEntity = await _produtoRepository.GetByIdAsync(id);
            produtoEntity.Categoria = await _categoriaRepository.GetByIdAsync(produtoEntity.CategoriaID);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task<ProdutoDTO> GetProdutoCategoriaAsync(int? id)
        {
            var produtoEntity = await _produtoRepository.GetProdutoCategoriaAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task AddAsync(ProdutoDTO produtoDTO)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.CreateAsync(produtoEntity);
        }

        public async Task UpdateAsync(ProdutoDTO produtoDTO)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.UpdateAsync(produtoEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var produtoEntity = _produtoRepository.GetByIdAsync(id).Result;
            await _produtoRepository.RemoveAsync(produtoEntity);
        }
    }
}
