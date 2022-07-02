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
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Ativo);
            builder.Property(p => p.Perecivel);

            builder.HasOne(e => e.Categoria).WithMany(e => e.Produto).HasForeignKey(e => e.CategoriaID);
        }
    }
}
