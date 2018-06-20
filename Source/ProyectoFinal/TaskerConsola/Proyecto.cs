using System;
using System.Collections.Generic;

namespace TaskerConsola
{
    class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int CantidadDeTareas
        {
            get
            { return this.Tareas.Count; }
        }
        public List<Tarea> Tareas { get;set; }

        public Proyecto()
        {
            this.Tareas=new List<Tarea>();
        }
    }
}
