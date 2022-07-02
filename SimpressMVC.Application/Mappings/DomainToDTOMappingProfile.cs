using AutoMapper;
using SimpressMVC.Application.DTOs;
using SimpressMVC.Domain.Entities;

namespace SimpressMVC.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<CategoriaProduto, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
