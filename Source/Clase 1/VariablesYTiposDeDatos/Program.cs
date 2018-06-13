using System;

namespace VariablesYTiposDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nombres de las variables deben
            //1. Empezar con letra o _
            //2. No pueden contener espacios
            //3. Al interior del nombre si puede tener números
            //4. Tampoco puede tener simbolos excepto _
            //5. C# es sensible a mayusculas y minusculas
            //Declarar una variable lleva 2 obligatorios y uno opcional
            //Obligatorio: Tipo de dato y nombre
            //Opcional: Valor
            double peso = 123.991;
            int edad = 33;
            
            float altura = 123.8f;
            bool hoyEsMartes = true; //false
            char unCaracter = 'z';
            string cadenaDeCaracteres = "esto es una cadena";

            //Var 
            var variable = 9867561;

            Console.Read();
        }
    }
}
