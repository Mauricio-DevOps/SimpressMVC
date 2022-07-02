using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpressMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpressMVC.Infra.Data.EntitiesConfiguration
{
    class CategoriaConfiguration : IEntityTypeConfiguration<CategoriaProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Ativo);

            builder.HasData(
                new CategoriaProduto(1, "Eletrônico", "Eletrodomésticos"),
                new CategoriaProduto(2, "Informática", "Produtos para Informática"),
                new CategoriaProduto(3, "Celulares", "Aparelhos e acessórios"),
                new CategoriaProduto(4, "Moda", "Artigos para vestuário em geral"),
                new CategoriaProduto(5, "Livros", "Livros")
                );
        }
    }
}
