using System;

namespace Arreglos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arreglos Unidimensionales = Vector
            //[ , , , , , , , ]
            //Los elementos son del mismo tipo
            //Tamaño = Cantidad de elementos
            //Inicio en 0
            //Ultima Tamaño-1
            //EJ: Vector de 10 Posiciones
            //[a,b,c,d,e,f,g,h,i,j]
            Console.Write("¿Cuantos estudiantes estan registrados?:");
            int cantidad = Convert.ToInt32(Console.ReadLine());

            //Declaración
            int[] edades = new int[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Ingrese la edad {i + 1}:");
                int edad = Convert.ToInt32(Console.ReadLine());
                edades[i] = edad; //Asignando datos al vector
            }
            double promedioEdad = 0;
            double sumatoria = 0;
            for (int i = 0; i < cantidad; i++)
            {
                sumatoria += edades[i];
            }
            promedioEdad = sumatoria / cantidad;
            Console.WriteLine($"El promedio de edad es {promedioEdad}");

            //Arreglos bidimensionales = Matricez
            int filas = 4;
            int columnas = 5;
            double[,] notas = new double[filas, columnas];
            //[a, , , , ]
            //[ , , , , ]
            //[ , , , , ]
            //[ , , , , ]
            Random aleatorio = new Random();
            for (int i = 0; i < filas; i++)
            {
                for (int y = 0; y < columnas; y++)
                {
                    notas[i, y] = aleatorio.NextDouble() * 10;
                }
            }
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write((notas[i, j]) + "\t");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write(Math.Floor(notas[i, j]) + "\t");
                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
