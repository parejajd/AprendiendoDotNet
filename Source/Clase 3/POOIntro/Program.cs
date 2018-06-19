using System;

namespace POOIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el tamaño del lado:");
            double lado = Convert.ToDouble(Console.ReadLine());

            Cuadrado cuadro = new Cuadrado(lado);


            Rectangulo rectangulo = new Rectangulo(10, 5);

            Console.Write("Ingrese el tamaño del lado del cubo:");
            double ladoDelCubo = Convert.ToDouble(Console.ReadLine());
            Cubo cubo = new Cubo(ladoDelCubo);
            Console.WriteLine($"Este cubo tiene los lados de {cubo.Lado} unidades");

            Triangulo triangulo = new Triangulo();
            triangulo.Altura = 8;
            triangulo.Base = 10;

            Circulo circulo = new Circulo();
            circulo.Radio = 3;

            ImprimirArea(cuadro);
            ImprimirArea(cubo);
            ImprimirArea(triangulo);
            ImprimirArea(circulo);
            ImprimirArea(rectangulo);

            Console.Read();
        }

        public static void ImprimirArea(FiguraGeometrica figura)
        {
            Console.WriteLine($"El area del {figura.GetType().Name}es {figura.CalcularArea()}");
        }
    }
}
