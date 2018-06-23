using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TaskerConsola
{
    class Program
    {
        const string RUTAARCHIVO = @"D:\Workspaces\CursoDotNet\Source\ProyectoFinal\TaskerConsola\BD";
        static List<Proyecto> todo = new List<Proyecto>();
        static void Main(string[] args)
        {
            Leer();
            string opcion = Menu();
            do
            {
                switch (opcion)
                {
                    case "1":
                        NuevaTarea();
                        break;
                    case "2":
                        ImprimirTarea();
                        break;
                    case "3":
                        ReporteVencidas();
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }

                opcion = Menu();
            } while (opcion.Equals("4") == false);
            Guardar();
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
                FechaMaxima = fechaMaxima,
                FechaCreacion = DateTime.Now
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

        static void ImprimirTarea()
        {
            Console.Clear();
            Console.WriteLine("Proyecto\t Tarea\t Descripción\t Fecha\t ¿Completada?");
            foreach (var proyecto in todo)
            {
                foreach (var tarea in proyecto.Tareas)
                {
                    Console.WriteLine($"{proyecto.Nombre}\t [{tarea.Id}]{tarea.Nombre} \t {tarea.Descripcion.Substring(0, 5)} \t\t  {tarea.FechaMaxima} \t {tarea.EstaTerminada}");
                }
            }

            Console.Write("Ingrese el ID de la tarea para ver los detalles o [0] para volver al menú:");

            string idTarea = Console.ReadLine();

            if (idTarea.Equals("0"))
            {
                return;
            }
            else
            {
                int id;
                if (int.TryParse(idTarea, out id))
                {
                    VerDetalleTarea(id);
                }
                else
                {
                    return;
                }
            }
        }

        static void ReporteVencidas()
        {
            Console.Clear();
            Console.WriteLine("Proyecto\t Tarea\t Descripción\t Fecha\t ¿Completada?");
            foreach (var proyecto in todo)
            {
                foreach (var tarea in proyecto.Tareas)
                {
                    //Vencidas
                    if (tarea.FechaMaxima < DateTime.Now)
                    {
                        ConsoleColor temp = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{proyecto.Nombre}\t [{tarea.Id}]{tarea.Nombre} \t {tarea.Descripcion.Substring(0, 5)} \t\t  {tarea.FechaMaxima} \t {tarea.EstaTerminada}");
                        Console.ForegroundColor = temp;
                    }
                    else
                    {
                        if (tarea.FechaMaxima.AddDays(-15) <= DateTime.Now)
                        {
                            ConsoleColor temp = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"{proyecto.Nombre}\t [{tarea.Id}]{tarea.Nombre} \t {tarea.Descripcion.Substring(0, 5)} \t\t  {tarea.FechaMaxima} \t {tarea.EstaTerminada}");
                            Console.ForegroundColor = temp;
                        }
                    }

                }
            }

            Console.ReadLine();
        }
        static void VerDetalleTarea(int id)
        {
            Console.Clear();
            //Buscar la tarea en el todo
            Tarea tareaEncontrada = new Tarea();
            bool encontreTarea = false;
            foreach (var elProyecto in todo)
            {
                foreach (var laTarea in elProyecto.Tareas)
                {
                    if (laTarea.Id == id)
                    {
                        tareaEncontrada = laTarea;
                        encontreTarea = true;
                        break;
                    }
                }
                if (encontreTarea == true)
                {
                    break;
                }
            }

            Console.WriteLine($"Id:{tareaEncontrada.Id}");
            Console.WriteLine($"Nombre:{tareaEncontrada.Nombre}");
            Console.WriteLine($"Descripcion:{tareaEncontrada.Descripcion}");
            Console.WriteLine($"FechaCreacion:{tareaEncontrada.FechaCreacion}");
            Console.WriteLine($"FechaMaxima:{tareaEncontrada.FechaMaxima.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"EstaTerminada:{tareaEncontrada.EstaTerminada}");
            if (tareaEncontrada.EstaTerminada)
            {
                Console.WriteLine($"FechaTerminacion:{tareaEncontrada.FechaTerminacion}");
            }
            Console.WriteLine("[1] Editar tarea, [2] Remover Tarea, [3] Completar Tarea, [0] Volver al menu");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    EditarTarea(id);
                    break;
                case "2":
                    RemoverTarea(id);
                    break;
                case "3":
                    CompletarTarea(id);
                    break;
                default:
                    return;
            }
        }

        static void EditarTarea(int id)
        {
            Console.Clear();
            //Buscar la tarea en el todo
            Tarea tareaEncontrada = new Tarea();
            bool encontreTarea = false;
            foreach (var elProyecto in todo)
            {
                foreach (var laTarea in elProyecto.Tareas)
                {
                    if (laTarea.Id == id)
                    {
                        tareaEncontrada = laTarea;
                        encontreTarea = true;
                        break;
                    }
                }
                if (encontreTarea == true)
                {
                    break;
                }
            }

            Console.WriteLine($"Nombre:{tareaEncontrada.Nombre}");
            Console.Write("Nuevo nombre:");
            string nuevoNombre = Console.ReadLine();
            if (string.IsNullOrEmpty(nuevoNombre) == false)
            {
                tareaEncontrada.Nombre = nuevoNombre;
                tareaEncontrada.FechaModificacion = DateTime.Now;
            }

            Console.WriteLine($"Descripcion:{tareaEncontrada.Descripcion}");
            Console.Write("Nueva descripcion:");
            string nuevoDescripcion = Console.ReadLine();
            if (string.IsNullOrEmpty(nuevoDescripcion) == false)
            {
                tareaEncontrada.Descripcion = nuevoDescripcion;
                tareaEncontrada.FechaModificacion = DateTime.Now;
            }
            Console.WriteLine($"FechaMaxima:{tareaEncontrada.FechaMaxima.ToString("dd/MM/yyyy")}");
            Console.Write("Nueva Fecha maxima:");
            string fechaTexto = Console.ReadLine();
            if (string.IsNullOrEmpty(fechaTexto) == false)
            {
                if (DateTime.TryParse(fechaTexto, out DateTime nuevaFecha))
                {
                    tareaEncontrada.FechaMaxima = nuevaFecha;
                    tareaEncontrada.FechaModificacion = DateTime.Now;
                }
            }
        }

        static void RemoverTarea(int id)
        {
            Console.Clear();
            //Buscar la tarea en el todo
            Tarea tareaEncontrada = new Tarea();
            bool encontreTarea = false;
            int posicionProyecto = 0;
            int posicionTarea = 0;

            int i = 0;
            int j = 0;
            foreach (var elProyecto in todo)
            {
                j = 0;
                foreach (var laTarea in elProyecto.Tareas)
                {
                    if (laTarea.Id == id)
                    {
                        posicionProyecto = i;
                        posicionTarea = j;
                        tareaEncontrada = laTarea;
                        break;
                    }
                    j++;
                }
                if (encontreTarea == true)
                {
                    break;
                }
                i++;
            }

            Console.Write("¿Esta seguro de eliminar la tarea?SI[S], NO[N]:");
            string opcion = Console.ReadLine().ToUpper();
            if (opcion.Equals("S"))
            {
                todo[posicionProyecto].Tareas.RemoveAt(posicionTarea);
                ConsoleColor temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("¡La tarea fue eliminada!");
                Console.ForegroundColor = temp;
                Console.WriteLine("Presiona una tecla para continuar");
                Console.Read();
            }
        }

        static void CompletarTarea(int id)
        {
            Console.Clear();
            //Buscar la tarea en el todo
            Tarea tareaEncontrada = new Tarea();
            bool encontreTarea = false;
            foreach (var elProyecto in todo)
            {
                foreach (var laTarea in elProyecto.Tareas)
                {
                    if (laTarea.Id == id)
                    {
                        tareaEncontrada = laTarea;
                        encontreTarea = true;
                        break;
                    }
                }
                if (encontreTarea == true)
                {
                    break;
                }
            }

            Console.Write("¿Esta seguro de completar la tarea?SI[S], NO[N]:");
            string opcion = Console.ReadLine().ToUpper();
            if (opcion.Equals("S"))
            {
                tareaEncontrada.EstaTerminada = true;

                tareaEncontrada.FechaTerminacion = DateTime.Now;
                ConsoleColor temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("¡La tarea fue completada!");
                Console.ForegroundColor = temp;
                Console.WriteLine("Presiona una tecla para continuar");
                Console.Read();
            }
        }


        static bool Guardar()
        {
            foreach (var proyecto in todo)
            {
                string fileName = $@"{RUTAARCHIVO}\{proyecto.Id}-{proyecto.Nombre}.txt";

                FileInfo info = new FileInfo(fileName);

                if (info.Exists)
                {
                    info.Delete();
                }

                StreamWriter writer = info.AppendText();
                foreach (var tarea in proyecto.Tareas)
                {
                    writer.WriteLine($"{tarea.Id};{tarea.Nombre};{tarea.Descripcion};{tarea.FechaCreacion};{tarea.FechaMaxima};{tarea.FechaModificacion};{tarea.EstaTerminada};{tarea.FechaTerminacion};");
                }
                writer.Close();

            }
            return true;
        }

        static bool Leer()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(RUTAARCHIVO);
            FileInfo[] archivos = directoryInfo.GetFiles();

            if (archivos.Length == 0)
            {
                todo.Add(new Proyecto
                {
                    Id = 1,
                    Nombre = "To do"
                });
            }
            else
            {
                foreach (var archivo in archivos)
                {
                    string nombreArchivo = archivo.Name.Replace(".txt", "");
                    string[] partes = nombreArchivo.Split('-');
                    Proyecto nuevoProyecto = new Proyecto
                    {
                        Id = Convert.ToInt32(partes[0]),
                        Nombre = partes[1]
                    };
                    todo.Add(nuevoProyecto);

                    using (FileStream file = archivo.OpenRead())
                    {
                        using (StreamReader reader = new StreamReader(file))
                        {
                            string line = "";

                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] datos = line.Split(';');
                                Tarea tarea = new Tarea
                                {
                                    Id = Convert.ToInt32(datos[0]),
                                    Nombre = datos[1],
                                    Descripcion = datos[2],
                                    FechaCreacion = Convert.ToDateTime(datos[3]),
                                    FechaMaxima = Convert.ToDateTime(datos[4]),
                                    EstaTerminada = Convert.ToBoolean(datos[6])
                                };

                                if (string.IsNullOrEmpty(datos[5]) == false)
                                {
                                    tarea.FechaModificacion = Convert.ToDateTime(datos[5]);
                                }

                                if (string.IsNullOrEmpty(datos[7]) == false)
                                {
                                    tarea.FechaTerminacion = Convert.ToDateTime(datos[7]);
                                }
                                nuevoProyecto.Tareas.Add(tarea);
                            }
                        }
                    }
                }

            }

            return true;
        }
    }
}
