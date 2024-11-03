using FluentValidation;
using Soma.Contracts.Requests;
using Soma.Api.Extensions;

namespace Soma.Api.Validators
{
    public class SomaRequestValidator : AbstractValidator<SomaRequest>
    {
        public SomaRequestValidator()
        {
            RuleFor(x => x.A)
                .NotNull()
                .WithMessage("'A' Não pode ser Nulo")
                .DependentRules(() =>
                {
                    RuleFor(x => x.A)
                           .Must(x => x?.IsValidDouble() == true)
                           .WithMessage("Informe apenas números");
                });

            RuleFor(x => x.B)
                .NotNull()
                .WithMessage("'B' Não pode ser Nulo")
                 .DependentRules(() =>
                 {
                     RuleFor(x => x.B)
                        .Must(x => x?.IsValidDouble() == true)
                        .WithMessage("Informe apenas números");
                 });
        }
    }
}
