using System;

namespace Interfaces2
{
    class Serpiente : ICaminable
    {
        public void Caminar(int distancia)
        {
            Console.Write("Arrastrandome.");
            for (int i = 0; i < distancia; i++)
            {
                Console.Write("...");
            }
        }
    }
}