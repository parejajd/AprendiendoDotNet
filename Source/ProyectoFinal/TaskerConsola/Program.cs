using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskerConsola
{
    class Program
    {
        static List<Proyecto> todo = new List<Proyecto>();
        static void Main(string[] args)
        {
            todo.Add(new Proyecto
            {
                Id = 1,
                Nombre = "To do"
            });

            string opcion = Menu();
            do
            {
                switch (opcion)
                {
                    case "1":
                        NuevaTarea();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }

                opcion = Menu();
            } while (opcion.Equals("4") == false);

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.Read();
        }

        static string Menu()
        {
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("Ingrese la opcion que necesita");
            Console.WriteLine("1. Para crear una nueva tarea");
            Console.WriteLine("2. Para ver el listado de tareas");
            Console.WriteLine("3. Para ver tareas por vencer/vencidas");
            Console.WriteLine("4. para salir");
            Console.WriteLine("Opcion: ");

            string opcion = Console.ReadLine();

            return opcion;
        }

        static void NuevaTarea()
        {
            Console.Clear();

            Console.WriteLine("*********Nueva tarea************");
            Console.Write("Nombre de la tarea:");
            string nombre = Console.ReadLine();
            Console.Write("Descripcion de la tarea:");
            string descripcion = Console.ReadLine();
            Console.Write("Fecha de la tarea:");
            DateTime fechaMaxima = Convert.ToDateTime(Console.ReadLine());

            Tarea nuevaTarea = new Tarea
            {
                Id = SiguienteId(),
                Nombre = nombre,
                Descripcion = descripcion,
                FechaMaxima = fechaMaxima
            };

            Console.Write("Proyecto: ");
            foreach (var proyecto in todo)
            {
                Console.Write($"[{proyecto.Id}]{proyecto.Nombre}  ");
            }
            Console.Write($"[0] Nuevo proyecto. Opcion:");

            string lectura = Console.ReadLine();

            if (lectura.Equals("0"))
            {
                Console.Write("Nombre del proyecto:");
                string nombreProyecto = Console.ReadLine();
                int proyectoId = SiguienteProyectoId();

                Proyecto nuevoProyecto = new Proyecto
                {
                    Id = proyectoId,
                    Nombre = nombreProyecto
                };
                nuevoProyecto.Tareas.Add(nuevaTarea);
                todo.Add(nuevoProyecto);

                ConsoleColor temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("¡La tarea fue creada!");
                Console.ForegroundColor = temp;
                Console.WriteLine("Presiona una tecla para continuar");
                Console.Read();
            }
            else
            {
                int opcionNumerica;
                if (int.TryParse(lectura, out opcionNumerica))
                {
                    bool encontreProyecto = false;
                    foreach (var proyecto in todo)
                    {
                        if (proyecto.Id == opcionNumerica)
                        {
                            proyecto.Tareas.Add(nuevaTarea);
                            encontreProyecto = true;
                            break;
                        }
                    }
                    if (encontreProyecto == false)
                    {
                        Console.WriteLine("Pailas, el proyecto no existe");
                    }
                    //Linq
                    /* 
                        Proyecto elProyecto = todo.FirstOrDefault(x => x.Id == opcionNumerica);
                        elProyecto.Tareas.Add(nuevaTarea);
                    */

                    ConsoleColor temp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("¡La tarea fue creada!");
                    Console.ForegroundColor = temp;
                    Console.WriteLine("Presiona una tecla para continuar");
                    Console.Read();
                }
                else
                {
                    Console.WriteLine("Usted se equivocó, formateare el equipo");
                }
            }
        }

        static int SiguienteId()
        {
            int siguienteId = 0;
            /** 
            for (int i = 0; i < todo.Count; i++)
            {
                Proyecto elProyecto = todo[i];
                for (int j = 0; j < elProyecto.Tareas.Count; j++)
                {
                    Tarea laTarea = elProyecto.Tareas[j];

                    if (siguienteId < laTarea.Id)
                    {
                        siguienteId = laTarea.Id;
                    }
                }
            }
            */

            foreach (var elProyecto in todo)
            {
                foreach (var laTarea in elProyecto.Tareas)
                {
                    if (siguienteId < laTarea.Id)
                    {
                        siguienteId = laTarea.Id;
                    }
                }
            }

            return siguienteId + 1;
        }

        static int SiguienteProyectoId()
        {
            int siguientProyectoId = 0;
            foreach (var proyecto in todo)
            {
                if (siguientProyectoId < proyecto.Id)
                {
                    siguientProyectoId = proyecto.Id;
                }
            }

            return siguientProyectoId + 1;
        }

    }
}
