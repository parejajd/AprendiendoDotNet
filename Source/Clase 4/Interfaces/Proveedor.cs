using System;
using System.IO; //Manejo de archivos

namespace Interfaces
{
    class Proveedor : Persona
    {
        public string NombreEmpresa { get; set; }
        public string NIT { get; set; }

        public override bool Login(string usuario, string contraseña)
        {
            //Abrir Archivo si existe, 
            //Buscar el nombre de usuario y contraseña en el archivo
            //si existe retornar true, si no retornar false

            string ruta = @"C:\Users\Paula Soler\Documents\Clase 4\Archivos\Empleados.txt";

            if (File.Exists(ruta))
            {
                StreamReader reader = File.OpenText(ruta);
                string contenido = reader.ReadToEnd();
                reader.Close();
            }

            return true;
        }
    }
}