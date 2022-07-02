using SimpressMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpressMVC.Domain.Entities
{
    public sealed class Produto : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public bool Perecivel { get; private set; }

        public Produto(string nome, string descricao, bool perecivel)
        {
            ValidateDomain(nome, descricao, perecivel);
        }
        public Produto(int id, string nome, string descricao, bool perecivel)
        {
            DomainExceptionValidation.When(id < 0, "Codigo Id invalido");
            Id = id;
            ValidateDomain(nome, descricao, perecivel);
        }

        /// <summary>
        /// Metodo para atualizar um Produto.
        /// </summary>
        /// <param name="nome">Nome do Produto</param>
        /// <param name="descricao">Descrição do Produto</param>
        /// <param name="perecivel">Se o Produto e perecivel</param>
        /// <param name="categoriaID">A qual categoria este produto pertence</param>
        public void Update(string nome, string descricao, bool perecivel, int categoriaID)
        {
            ValidateDomain(nome, descricao, perecivel);
            CategoriaID = categoriaID;
        }

        /// <summary>
        /// Metodo utilizado para adicionar as regras de negocio para validação da ciração de um produto.
        /// </summary>
        /// <param name="nome">Nome do Produto</param>
        /// <param name="descricao">Descrição do Produto</param>
        /// <param name="perecivel">Se o Produto e perecivel</param>
        private void ValidateDomain(string nome, string descricao, bool perecivel)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome e obrigatorio");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição e obrigatorio");

            Nome = nome;
            Descricao = descricao;
            Ativo = true;
            Perecivel = perecivel;
        }

        public int CategoriaID { get; set; }
        public CategoriaProduto Categoria { get; set; }
    }
}
