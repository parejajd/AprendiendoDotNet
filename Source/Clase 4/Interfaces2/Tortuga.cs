using System;

namespace Interfaces2
{
    class Tortuga : ICaminable
    {
        public void Caminar(int distancia)
        {
            Console.Write("Caminando muy despacio.");
            for (int i = 0; i < distancia; i++)
            {
                Console.Write("......");
            }
        }
    }
}