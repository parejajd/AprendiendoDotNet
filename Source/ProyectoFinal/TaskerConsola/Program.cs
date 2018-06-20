using System;

namespace TaskerConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Proyecto cursoDotNet = new Proyecto();
            cursoDotNet.Id = 1;
            cursoDotNet.Nombre = "Curso de .net";
            cursoDotNet.Tareas.Add(new Tarea
            {
                Id = 1,
                Nombre = "Preparar las ppts"
            });

            cursoDotNet.Tareas.Add(new Tarea
            {
                Id = 2,
                Nombre = "Comprar Cafe"
            });

            cursoDotNet.Tareas.Add(new Tarea
            {
                Id = 3,
                Nombre = "Comprar Agua"
            });

            Console.Read();
        }
    }
}
