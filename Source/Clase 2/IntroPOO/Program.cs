using System;

namespace IntroPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instanciación de un objeto
            //¿Que es un objeto?
            //Instancia de una clase
            //Instancia: Asignar valores a las propiedades definidas en una clase
            Tarea tarea1 = new Tarea();
            tarea1.Nombre = "Realizar un backup";
            tarea1.Descripcion = "Ingresar al servicio xyz y hacer una copia de los archivos...";
            tarea1.FechaHora = DateTime.Now.AddDays(1);
            tarea1.TiempoEjecucion = 2;

            tarea1.MarcarComoCompletada("se realizó el backup y se guardo en el disco externo");

            Tarea tarea2 = new Tarea();
            tarea2.Nombre = "Realizar un informe del backup";
            tarea2.Descripcion = "Documentar en el formato de calidad 123 la tarea realiozada";
            tarea2.FechaHora = DateTime.Now.AddDays(1);
            tarea2.TiempoEjecucion = 1;

            bool sePudoPosponer = tarea2.PosponerTarea(6);

            if (sePudoPosponer == true)
            {
                Console.WriteLine($"Excelente, la tarea quedó asignada para el {tarea2.FechaHora}");
            }
            else
            {
                Console.WriteLine("No dejes para mañana lo que puedes hacer hoy");
            }

            Console.Read();
        }
    }
}
