using System;

namespace Interfaces2
{
    class Humano : ICaminable
    {
        public void Caminar(int distancia)
        {
            Console.Write("Caminando como un humano.");
            for (int i = 0; i < distancia; i++)
            {
                Console.Write(".");
            }
        }
    }
}