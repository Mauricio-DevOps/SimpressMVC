using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpressMVC.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategoriaProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategoriaProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Perecivel = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProduto_tblCategoriaProduto_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "tblCategoriaProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCategoriaProduto",
                columns: new[] { "Id", "Ativo", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, true, "Eletrodomésticos", "Eletrônico" },
                    { 2, true, "Produtos para Informática", "Informática" },
                    { 3, true, "Aparelhos e acessórios", "Celulares" },
                    { 4, true, "Artigos para vestuário em geral", "Moda" },
                    { 5, true, "Livros", "Livros" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProduto_CategoriaID",
                table: "tblProduto",
                column: "CategoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProduto");

            migrationBuilder.DropTable(
                name: "tblCategoriaProduto");
        }
    }
}
