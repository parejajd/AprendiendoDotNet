using System;
using System.IO; //Manejo de archivos

namespace Interfaces
{
    class Cliente : Persona
    {
        public string DireccionEntrega { get; set; }


        public override bool Login(string usuario, string contraseña)
        {
            string ruta = @"D:\Workspaces\CursoDotNet\Source\Clase 4\Interfaces\Archivos\Clientes.txt";
            bool logueado = false;
            if (File.Exists(ruta))
            {
                StreamReader reader = File.OpenText(ruta);
                string linea;

                while ((linea = reader.ReadLine()) != null)
                {
                    string[] datos = linea.Split(';');

                    if (datos[0].Equals(usuario) && datos[1].Equals(contraseña))
                    {
                        logueado = true;
                        break;
                    }
                }
                reader.Close();
            }

            return logueado;
        }
    }
}