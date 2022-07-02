using System.ComponentModel.DataAnnotations;

namespace SimpressMVC.Application.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome e Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Descrição e Obrigatorio")]
        public string Descricao { get; set; }
    }
}
