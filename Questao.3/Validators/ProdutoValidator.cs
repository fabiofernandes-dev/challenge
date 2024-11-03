//using FluentValidation;
using FluentValidation;
using Questao._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao._3.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x)
                .Must(x => x.ValorVenda > x.ValorCompra)
                .WithMessage($"Valor da venda deve ser maior que o valor da compra");

            RuleFor(x => x.ValorVenda)
                .GreaterThan(0.0)
                .WithMessage($"Valor da venda deve ser maior que 0");

            RuleFor(x => x.DataCriacao)
                .GreaterThanOrEqualTo(new DateTime(2024, 01, 01))
                .WithMessage($"Data de criação deve ser maior que 01/01/2024");

            RuleFor(x => x.Descricao)
                .MinimumLength(5)
                .WithMessage($"Descrição deve ter no mínimo 5 caracteres");

            RuleFor(x => x.ValorCompra)
                .GreaterThan(0.0)
                .WithMessage($"Valor da compra deve ser maior que 0");

            RuleFor(x => x.Tipo)
                .IsInEnum()                
                .WithMessage("Tipo de produto inválido");
        }
    }
}
