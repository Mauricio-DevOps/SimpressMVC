using SimpressMVC.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpressMVC.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetCategoriaAsync();
        Task<CategoriaDTO> GetByIdAsync(int? id);
        Task AddAsync(CategoriaDTO categoriaDTO);
        Task UpdateAsync(CategoriaDTO categoriaDTO);
        Task RemoveAsync(int? id);

    }
}
