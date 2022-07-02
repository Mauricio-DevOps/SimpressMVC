using SimpressMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpressMVC.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutoAsync();
        Task<ProdutoDTO> GetByIdAsync(int? id);

        Task<ProdutoDTO> GetProdutoCategoriaAsync(int? id);
        Task AddAsync(ProdutoDTO produtoDTO);
        Task UpdateAsync(ProdutoDTO produtoDTO);
        Task RemoveAsync(int? id);
    }
}
