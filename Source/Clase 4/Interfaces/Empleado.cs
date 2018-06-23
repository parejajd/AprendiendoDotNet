using System;
using System.IO; //Manejo de archivos

namespace Interfaces
{
    class Empleado : Persona, ILogueable
    {
        public double Salario { get; }

        public Empleado(double salario)
        {
            this.Salario = salario;
        }

        public override bool Login(string usuario, string contraseña)
        {
            //Verificar si existe, si true
            //Abrir un archivo
            //buscar el nombre de usuario y la contraseña en el archivo
            //si existe retornar true, si no, retornar false.
            string ruta = @"D:\Workspaces\CursoDotNet\Source\Clase 4\Interfaces\Archivos\Empleados.txt";
            bool logueado = false;
            if (File.Exists(ruta))
            {
                StreamReader reader = File.OpenText(ruta);
                string linea;

                while ((linea = reader.ReadLine()) != null)
                {
                    string[] datos = linea.Split(';');
                    //Ejemplo
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

        public void Log(string datos)
        {
            //Registrar en la bitácora de eventos
            Console.WriteLine($"se registro el evento {datos}");
        }
    }
}