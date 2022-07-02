using FluentAssertions;
using SimpressMVC.Domain.Entities;
using System;
using Xunit;

namespace SimpressMVC.Domain.Tests
{
    public class CategoriaUnitTest1
    {
        [Fact]
        public void CreateCategoria_ParametrosValidos_RetornoObjetoValido()
        {
            Action action = () => new CategoriaProduto(1, "Nome Categoria", "Descrição");
            action.Should()
                .NotThrow<SimpressMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategoria_ParametrosIdNegativo_RetornoObjetoInvalido()
        {
            Action action = () => new CategoriaProduto(-1, "Nome Categoria", "Descrição");
            action.Should().Throw<SimpressMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Codigo Id invalido");
                
        }

        [Fact]
        public void CreateCategoria_ParametrosNomeNulo_RetornoObjetoInvalido()
        {
            Action action = () => new CategoriaProduto(1, null, "Descrição");
            action.Should().Throw<SimpressMVC.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact]
        public void CreateCategoria_ParametrosDescricaoNulo_RetornoObjetoInvalido()
        {
            Action action = () => new CategoriaProduto(1, "Nome Categoria", null);
            action.Should().Throw<SimpressMVC.Domain.Validation.DomainExceptionValidation>();

        }

    }
}
