using SimpressMVC.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimpressMVC.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome e Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Descrição e Obrigatorio")]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Informe se o produto e Perecivel")]
        public bool Perecivel { get; set; }

        
        public CategoriaProduto Categoria { get; set; }

        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }
    }
}
