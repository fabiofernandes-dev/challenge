using FluentValidation;
using Soma.Api.Models;

namespace Soma.Api.Validators
{
    public class AdicaoValidator: AbstractValidator<Adicao>
    {
        public AdicaoValidator()
        {            
            RuleFor(x => x.PrimeiraParcela)
                .NotNull();

            RuleFor(x => x.SegundaParcela)
                .NotNull();            
        }
    }
}
