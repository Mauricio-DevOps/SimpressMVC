using SimpressMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpressMVC.Domain.Entities
{
    public sealed class CategoriaProduto : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private  set; }

        public CategoriaProduto(string nome, string descricao)
        {
            ValidateDomain(nome, descricao);
        }
        public CategoriaProduto(int id, string nome, string descricao)
        {
            DomainExceptionValidation.When(id < 0, "Codigo Id invalido");
            Id = id;
            ValidateDomain(nome, descricao);
        }

        /// <summary>
        /// Metodo para atualizar uma Categoria.
        /// </summary>
        /// <param name="nome">Nome da Categoria</param>
        /// <param name="descricao">Descrição da Categoria</param>
        public void Update (string nome, string descricao)
        {
            ValidateDomain(nome, descricao);
        }

        public ICollection<Produto> Produto { get; set; }

        /// <summary>
        /// Metodo utilizado para adicionar as regras de negocio para validação da ciração de uma nova Categoria.
        /// </summary>
        /// <param name="nome">Nome da Categoria</param>
        /// <param name="descricao">Descrição da Categoria</param>
        private void ValidateDomain(string nome, string descricao)
        {
            //Cria toda a logica de Validação

            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), 
                "Nome e obrigatorio");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição e obrigatorio");

            Nome = nome;
            Descricao = descricao;
            Ativo = true;
        }
    }
}
