using System.Collections.Generic;

namespace IntroMVC
{
    public class Reporte
    {
        public Usuario Usuario { get; set; }
        public List<Proyecto> Proyectos { get; set; }
    }
}