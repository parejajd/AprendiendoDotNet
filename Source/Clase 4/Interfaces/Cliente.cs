using System;
using System.IO; //Manejo de archivos

namespace Interfaces
{
    class Cliente : Persona
    {
        public string DireccionEntrega { get; set; }


        public override bool Login(string usuario, string contraseña)
        {
            //Verificar si existe, si true
            //Abrir un archivo
            //buscar el nombre de usuario y la contraseña en el archivo
            //si existe retornar true, si no, retornar false.
            string ruta = @"D:\Workspaces\CursoDotNet\Source\Clase 4\Interfaces\Archivos\Empleados.txt";
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