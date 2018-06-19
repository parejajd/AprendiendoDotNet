using System;

namespace POOIntro
{
    class Cubo : Cuadrado
    {
        public Cubo(double lado) : base(lado)
        {
            
        }

        public override double CalcularArea()
        {
            return Math.Pow(Lado, 3); //1 forma de calcular
        }
    }
}