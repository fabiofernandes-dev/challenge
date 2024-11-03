namespace Soma.Api.Models
{
    public class Adicao
    {
        public double PrimeiraParcela { get; set; }
        public double SegundaParcela { get; set; }

        public double Calcular() => PrimeiraParcela + SegundaParcela;
    }
}
