using SimpressMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpressMVC.Domain.Interfaces
{
    public interface ICategoriaProdutoRepository
    {
        Task<IEnumerable<CategoriaProduto>> GetCategoriasAsync();
        Task<CategoriaProduto> GetByIdAsync(int? id);

        Task<CategoriaProduto> CreateAsync(CategoriaProduto tblCategoriaProduto);
        Task<CategoriaProduto> UpdateAsync(CategoriaProduto tblCategoriaProduto);
        Task<CategoriaProduto> RemoveAsync(CategoriaProduto tblCategoriaProduto);
    }
}
