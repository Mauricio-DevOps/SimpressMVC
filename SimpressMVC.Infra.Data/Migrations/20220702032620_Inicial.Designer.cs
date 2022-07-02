﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpressMVC.Infra.Data.Context;

namespace SimpressMVC.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220702032620_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpressMVC.Domain.Entities.CategoriaProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("tblCategoriaProduto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Descricao = "Eletrodomésticos",
                            Nome = "Eletrônico"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Descricao = "Produtos para Informática",
                            Nome = "Informática"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Descricao = "Aparelhos e acessórios",
                            Nome = "Celulares"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Descricao = "Artigos para vestuário em geral",
                            Nome = "Moda"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            Descricao = "Livros",
                            Nome = "Livros"
                        });
                });

            modelBuilder.Entity("SimpressMVC.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Perecivel")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaID");

                    b.ToTable("tblProduto");
                });

            modelBuilder.Entity("SimpressMVC.Domain.Entities.Produto", b =>
                {
                    b.HasOne("SimpressMVC.Domain.Entities.CategoriaProduto", "Categoria")
                        .WithMany("Produto")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("SimpressMVC.Domain.Entities.CategoriaProduto", b =>
                {
                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
