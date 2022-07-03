using FluentValidation;
using SimpressMVC.WebUI.Models.Response;

namespace SimpressMVC.WebUI.Models.Validator
{
    public class CreateProdutoValidator : AbstractValidator<ProdutoResponse>
    {
        public CreateProdutoValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome e obrigatorio");
            RuleFor(x => x.Descricao)
                .NotNull().WithMessage("Descricao e obrigatorio");
            RuleFor(x => x.CategoriaId)
                .NotNull().WithMessage("Id da Categoria e obrigatorio");
            RuleFor(x => x.Ativo)
                .NotNull().WithMessage("Ativo e obrigatorio");
            RuleFor(x => x.Perecivel)
                .NotNull().WithMessage("Perecivel e obrigatorio");
        }
    }
}
