using FluentValidation.Results;
using Questao._3.Enums;
using Questao._3.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao._3.Models
{
    public class Produto
    {
        public required string Descricao { get; set; }
        public double ValorVenda { get; set; }
        public double ValorCompra { get; set; }
        public Tipo Tipo { get; set; }
        public DateTime DataCriacao { get; set; }

        public double CalcularLucro() => ValorVenda - ValorCompra;
        public ValidationResult RegrasValidas()
        {
            return new ProdutoValidator().Validate(this);           
        }
    }    
}
