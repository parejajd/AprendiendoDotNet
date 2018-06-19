using System;

namespace POOIntro
{
    class Circulo : FiguraGeometrica
    {
        public double Radio { get; set; }
        public override double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }
    }
}
