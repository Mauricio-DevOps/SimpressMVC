using FluentAssertions;
using SimpressMVC.Domain.Entities;
using System;
using Xunit;

namespace SimpressMVC.Domain.Tests
{
    public class ProdutoUnitTest1
    {
        [Fact]
        public void CreateProduto_ParametrosValidos_RetornoObjetoValido()
        {
            Action action = () => new Produto(1, "Nome Produto", "Descrição Produto", true);
            action.Should()
                .NotThrow<SimpressMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduto_ParametrosIdNegativo_RetornoObjetoInvalido()
        {
            Action action = () => new Produto(-1, "Nome Produto", "Descrição Produto", true);
            action.Should().Throw<SimpressMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Codigo Id invalido");
        }

        [Fact]
        public void CreateProduto_ParametrosNomeNulo_RetornoObjetoInvalido()
        {
            Action action = () => new Produto(1, null, "Descrição Produto", true);
            action.Should().Throw<SimpressMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduto_ParametrosDescricaoNulo_RetornoObjetoInvalido()
        {
            Action action = () => new Produto(1, "Nome Produto", null, true);
            action.Should().Throw<SimpressMVC.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
