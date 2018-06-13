using System;

namespace LaClaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Escribir
            Console.WriteLine("Bienvenidos al curso de .NET de CreApps");
            Console.WriteLine("¿Como vamos?");
            Console.Write("(1) Si está confundido, (2) si está muy confundido:");
            //Leer de la consola
            string opcion = Console.ReadLine();

            Console.WriteLine("Usted ingreso:" + opcion);

            Console.WriteLine("Ingrese su nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su edad:");
            string cadenaEdad = Console.ReadLine();
            int edad = Convert.ToInt32(cadenaEdad);

            Console.WriteLine("Ingrese su estatura en metros:");
            string cadenaEstatura = Console.ReadLine();
            double estatura = Convert.ToDouble(cadenaEstatura);

            Console.WriteLine("Ingrese su pese:");
            double peso = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Bienvenido " + nombre);

            //Operaciones con variables
            //Operadores: Matemáticos/Aritméticos + - * / () =
            double relacion = Math.Pow(estatura, 2) / peso;
            double operacion = 4 + 5 * 8 / 4;
            //Precedencia de operadores 
            //1. ()
            //2. * / Si hay de ambas derecha a izquierda
            //3. + -
            //4. =

            //Operadores relacionales
            // < > <= >= != ==
            bool resultado = edad > 18;

            //Operadores booleanos
            // && AND
            // || OR
            // ! NOT 
            int hora = 5;
            string dia = "Martes";

            bool hayCurso = dia == "Martes" && hora > 6;
            bool condicion = dia == "Martes" || hora > 6;

            Console.Read();
        }
    }
}
