using FluentValidation;
using SimpressMVC.WebUI.Models.Response;

namespace SimpressMVC.WebUI.Models.Validator
{
    public class CreateCategoriaValidator : AbstractValidator<CategoriaResponse>
    {
        public CreateCategoriaValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome e obrigatorio");
            RuleFor(x => x.Descricao)
                .NotNull().WithMessage("Nome e obrigatorio");
        }
    }
}
