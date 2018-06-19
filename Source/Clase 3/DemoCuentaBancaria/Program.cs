using System;

namespace DemoCuentaBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Cuenta laCuenta = new Cuenta();
            laCuenta.NombrePersona = "Juan David Pareja Soto";
            laCuenta.NroCuenta = "123-987456";

            Console.WriteLine($"El saldo actual es {laCuenta.Saldo}");
            //Consignacion= 10.000
            laCuenta.Consignar(100_000);
            Console.WriteLine($"El saldo actual es {laCuenta.Saldo}");

            //Retiro: 4000
            //laCuenta.Saldo = laCuenta.Saldo - 500_000 - 4_000;
            bool sePudoRetirar = laCuenta.Retirar(80000);
            if (sePudoRetirar == true)
            {
                Console.WriteLine($"El saldo actual es {laCuenta.Saldo}");
            }
            else
            {
                Console.WriteLine("Lo sentimos, usted no tiene fondos");
            }

            Console.Read();
        }
    }
}
