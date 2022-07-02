using Microsoft.EntityFrameworkCore;
using SimpressMVC.Domain.Entities;
using SimpressMVC.Domain.Interfaces;
using SimpressMVC.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpressMVC.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        ApplicationDbContext _produtoContext;
        public ProdutoRepository(ApplicationDbContext context)
        {
            _produtoContext = context;
        }

        public async Task<Produto> CreateAsync(Produto tblProduto)
        {
            _produtoContext.Add(tblProduto);
            await _produtoContext.SaveChangesAsync();
            return tblProduto;
        }

        public async Task<Produto> GetByIdAsync(int? id)
        {
            return await _produtoContext.tblProduto.FindAsync(id);
        }

        public async Task<Produto> GetProdutoCategoriaAsync(int? id)
        {
            return await _produtoContext.tblProduto.Include(c => c.Categoria)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _produtoContext.tblProduto.Include(c=>c.Categoria).ToListAsync();
        }

        public async Task<Produto> RemoveAsync(Produto tblProduto)
        {
            _produtoContext.Remove(tblProduto);
            await _produtoContext.SaveChangesAsync();
            return tblProduto;
        }

        public async Task<Produto> UpdateAsync(Produto tblProduto)
        {
            _produtoContext.Update(tblProduto);
            await _produtoContext.SaveChangesAsync();
            return tblProduto;
        }
    }
}
