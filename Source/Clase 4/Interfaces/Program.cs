﻿using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Empleado empleado = new Empleado(1000);
            bool loginOk=empleado.Login("cpflorez","1234");
            
            Console.Read();
        }
    }
}
