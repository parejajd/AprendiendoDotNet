using System;

namespace TaskerConsola
{
    class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMaxima { get; set; }
        public bool EstaTerminada { get; set; }
        public DateTime FechaTerminacion { get; set; }
    }
}