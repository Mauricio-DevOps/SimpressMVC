using FluentValidation;
using SimpressMVC.WebUI.Models.Response;

namespace SimpressMVC.WebUI.Models.Validator
{
    public class CreateProdutoResponse : AbstractValidator<ProdutoResponse>
    {
        public CreateProdutoResponse()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome e obrigatorio");
            RuleFor(x => x.Descricao)
                .NotNull().WithMessage("Nome e obrigatorio");
            RuleFor(x => x.CategoriaId)
                .NotNull().WithMessage("Nome e obrigatorio");
            RuleFor(x => x.Ativo)
                .NotNull().WithMessage("Nome e obrigatorio");
            RuleFor(x => x.Perecivel)
                .NotNull().WithMessage("Nome e obrigatorio");
        }
    }
}
