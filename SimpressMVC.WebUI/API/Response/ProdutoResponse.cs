using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpressMVC.WebUI.API.Response
{

    public class ProdutoResponse
    {
        public Class1[] Produtos { get; set; }
    }

    public class Class1
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }
        public bool perecivel { get; set; }
        public Categoria categoria { get; set; }
        public int categoriaId { get; set; }
    }

    public class Categoria
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }
        public Produto[] produto { get; set; }
        public int id { get; set; }
    }

    public class Produto
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }
        public bool perecivel { get; set; }
        public int categoriaID { get; set; }
        public int id { get; set; }
    }


}
