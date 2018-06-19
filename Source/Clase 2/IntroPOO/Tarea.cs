using System;

//Espacio de nombres comun de la aplicación
namespace IntroPOO
{
    //Definir una clase
    //Clase: Plantilla para definir objetos
    //       donde se establecen las caracteristicas y comportamiento 
    //       de dichos objetos
    //Visibilidad: 
    //  -Private: Solo puede ser accedida por la misma clase
    //  -Public:  Se puede acceder desde fuera de la clase
    //  -Protected: Solo se puede acceder desde las clases hijas
    //  -Internal: Parecida la publica, pero solo se accede desde el mismo programa
    class Tarea
    {
        //Propiedades - Atributos - Caracteristicas
        public string Nombre { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public int TiempoEjecucion { get; set; }
        public bool EstaTerminada { get; set; }
        public string Reporte { get; set; }
        public DateTime FechaCompletado { get; set; }

        //Métodos = Comportamiento
        //Constructor = Crear un objeto de la clase
        public Tarea()
        {
            EstaTerminada = false;
            Reporte = "No se ha ejecutado aún";
        }


        //Métodos de instancia
        //Firma (visibilidad, tipo de retorno, nombre, parámetros)
        public void MarcarComoCompletada(string reporteEjecucion)
        {
            EstaTerminada = true;
            Reporte = reporteEjecucion;
            FechaCompletado = DateTime.Now;
        }

        public bool PosponerTarea(int cantidadDeDias)
        {
            Random
            DateTime posibleFecha = FechaHora.AddDays(cantidadDeDias);

            if (posibleFecha.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            else
            {
                FechaHora = posibleFecha;
                return true;
            }
        }
    }
}