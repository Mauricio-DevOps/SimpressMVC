using Microsoft.EntityFrameworkCore;
using SimpressMVC.Domain.Entities;
using SimpressMVC.Domain.Interfaces;
using SimpressMVC.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpressMVC.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaProdutoRepository
    {
        ApplicationDbContext _categoriaContext;
        public CategoriaRepository(ApplicationDbContext context)
        {
            _categoriaContext = context;
        }

        public async Task<CategoriaProduto> CreateAsync(CategoriaProduto tblCategoriaProduto)
        {
            _categoriaContext.Add(tblCategoriaProduto);
            await _categoriaContext.SaveChangesAsync();
            return tblCategoriaProduto;
        }

        public async Task<CategoriaProduto> GetByIdAsync(int? id)
        {
            return await _categoriaContext.tblCategoriaProduto.FindAsync(id);
        }

        public async Task<IEnumerable<CategoriaProduto>> GetCategoriasAsync()
        {
            return await _categoriaContext.tblCategoriaProduto.ToListAsync();
        }

        public async Task<CategoriaProduto> RemoveAsync(CategoriaProduto tblCategoriaProduto)
        {
            _categoriaContext.Remove(tblCategoriaProduto);
            await _categoriaContext.SaveChangesAsync();
            return tblCategoriaProduto;
        }

        public async Task<CategoriaProduto> UpdateAsync(CategoriaProduto tblCategoriaProduto)
        {
            _categoriaContext.Update(tblCategoriaProduto);
            await _categoriaContext.SaveChangesAsync();
            return tblCategoriaProduto;
        }
    }
}
