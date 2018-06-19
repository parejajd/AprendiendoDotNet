

namespace POOIntro
{
    class Rectangulo : FiguraGeometrica
    {
        public double Base { get; }
        public double Altura { get; }

        public Rectangulo(double laBase, double altura)
        {
            this.Base = laBase;
            this.Altura = altura;
        }

        public override double CalcularArea()
        {
            return this.Base * this.Altura;
        }
    }
}