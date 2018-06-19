using System;

namespace POOIntro
{
    class Cuadrado : FiguraGeometrica
    {
        public double Lado { get; set; }

        public Cuadrado(double lado)
        {
            this.Lado = lado;
        }

        public override double CalcularArea()
        {
            return Math.Pow(Lado, 2); //1 forma de calcular
        }
    }
}