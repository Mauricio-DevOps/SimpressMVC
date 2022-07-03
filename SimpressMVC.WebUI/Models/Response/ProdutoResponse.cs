using System.ComponentModel.DataAnnotations;

namespace SimpressMVC.WebUI.Models.Response
{
    public class ProdutoResponse
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public bool Perecivel { get; set; }

        public CategoriaResponse Categoria { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public int CategoriaId { get; set; }
    }
}
