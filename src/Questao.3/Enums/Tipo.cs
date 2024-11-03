using Microsoft.OpenApi.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao._3.Enums
{
    public enum Tipo
    {
        [Display("Final")]
        Final =1,
        [Display("Intermediário")]
        Intermediario = 2,
        [Display("Consumo")]
        Consumo = 3,
        [Display("Matéria-prima")]
        MateriaPrima = 4
    }
}
