using System;

namespace Sentencias
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistemas de notas.....");
            ConsoleKeyInfo tecla;
            do
            {
                Console.WriteLine();
                 Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ingrese la Nota 1:");
                double nota1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingrese la Nota 2:");
                double nota2 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingrese la Nota 3:");
                double nota3 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingrese la Nota 4:");
                double nota4 = Convert.ToDouble(Console.ReadLine());

                double promedio = (nota1 + nota2 + nota3 + nota4) / 4;

                if (promedio < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pailas! Perdió Nota:" + promedio);
                }
                else
                {
                    if (promedio >= 3 && promedio < 4.5)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Felicitaciones, pasó" + promedio);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Mas felicitaciones, ganó beca." + promedio);
                    }
                }

                Console.Write("Si desea continuar presione 1. Para terminar presione 2:");
                tecla = Console.ReadKey();

            } while (tecla.Key == ConsoleKey.NumPad1);


            Console.Read();
        }
    }
}
