using SimpressMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpressMVC.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> GetByIdAsync(int? id);

        Task<Produto> GetProdutoCategoriaAsync(int? id);

        Task<Produto> CreateAsync(Produto tblProduto);
        Task<Produto> UpdateAsync(Produto tblProduto);
        Task<Produto> RemoveAsync(Produto tblProduto);
    }
}
