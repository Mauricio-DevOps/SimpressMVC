using SimpressMVC.Application.DTOs;
using SimpressMVC.Application.Interfaces;
using SimpressMVC.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpressMVC.WebUI.Models
{
    public class MyViewModel 
    {
        public IEnumerable<CategoriaDTO> categoria { get; set; }
        public IEnumerable<ProdutoDTO> produto { get; set; }
    }
}
