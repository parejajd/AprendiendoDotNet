using System;

namespace Interfaces2
{
    class Program
    {
        static void Main(string[] args)
        {
            Humano yo = new Humano();
            Tortuga laTortuga = new Tortuga();
            Serpiente laSerpiente = new Serpiente();
            Villano elVillano = new Villano();

            HacerCaminar(yo, 10);
            HacerCaminar(laTortuga, 10);
            HacerCaminar(laSerpiente, 10);
            HacerCaminar(elVillano, 10);
            Console.Read();
        }

        public static void HacerCaminar(ICaminable personaje, int distancia)
        {
            //Se agrega este cambio
            personaje.Caminar(distancia);
            Console.WriteLine();
        }
    }
}
