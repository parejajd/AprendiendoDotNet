using System;

namespace Cadenas
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadena = "esto es una cadena";

            //Inmutable
            cadena = "Bienvenidos al curso de .NET " + "de CreApps"; //Concatenación Pegar dos cadenas
            cadena += " Hoy dia Sábado de mundial"; //cadena=cadena+"laksñka"

            string diaDeReunion = "Cada dia tendremos " + 2 + " Horas de trabajo";

            string numero1 = "123";
            int numero2 = 456;
            string resultado = numero1 + numero2;


            Console.WriteLine("Mayúsculas:" + cadena.ToUpper());
            Console.WriteLine("Minúsculas:" + cadena.ToLower());
            Console.WriteLine("Substring:" + cadena.Substring(0, 10));
            Console.WriteLine("Contains:" + cadena.Contains(".NET"));
            Console.WriteLine("Equals:" + cadena.Equals(".NET"));
            Console.WriteLine("Index of:" + cadena.IndexOf(".NET"));
            Console.WriteLine("Lenght:" + cadena.Length);
            Console.WriteLine("Remove:" + cadena.Remove(0, 10));
            Console.WriteLine("Replace:" + cadena.Replace(".NET", "Java"));
            string valores = "1,2,3,4,5,6,7";
            string[] arreglo = valores.Split(',');

            string temario = "Los \"temas\" son \n \v 1. Net\n 2.Visual Studio\n \t 2.1 Visual Studio Code\n \t 2.2 Visual Communiyt \\ aaa";

            Console.WriteLine(temario);
            
            //Verbatim operator
            string otroTemario=@"Los 'temas' son \n \v 1. Net\n 2.Visual Studio\n"+ "\t 2.1 Visual Studio Code\n \t 2.2 Visual Communiyt \\ aaa";
            
            Console.WriteLine(otroTemario);

            string nombre="Juan David";
            string apellido="Pareja Soto";

            string bienvenido= $"Bienvenido {nombre} {apellido} al curso de .net es la clase {3}";
            Console.WriteLine(bienvenido);

            Console.Read();
        }
    }
}
