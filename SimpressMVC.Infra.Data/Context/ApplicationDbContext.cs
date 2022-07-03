using Microsoft.EntityFrameworkCore;
using SimpressMVC.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SimpressMVC.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<CategoriaProduto> tblCategoriaProduto { get; set; }
        public DbSet<Produto> tblProduto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
