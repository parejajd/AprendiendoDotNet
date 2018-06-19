
namespace POOIntro
{
    class Triangulo : FiguraGeometrica
    {
        public double Base { get; set; }
        public double Altura { get; set; }
        
        public override double CalcularArea()
        {
            return (this.Base * this.Altura) / 2;
        }
    }
}