using System;

namespace ManejoDeFechas
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime hoy = DateTime.Now;
            Console.WriteLine($"La fecha de hoy es {hoy}");
            Console.WriteLine($"La fecha (sola) de hoy es {hoy.Date}");
            Console.WriteLine($"La hora (sola) de hoy es {hoy.TimeOfDay}");

            Console.WriteLine($"El año de hoy es {hoy.Year}");
            Console.WriteLine($"El mes de hoy es {hoy.Month}");
            Console.WriteLine($"El dia de hoy es {hoy.Day}");
            Console.WriteLine($"El hora de hoy es {hoy.Hour}");
            Console.WriteLine($"El minuto de hoy es {hoy.Minute}");
            Console.WriteLine($"El segundo de hoy es {hoy.Second}");

            Console.WriteLine($"dia respecto a la semana de hoy es {hoy.DayOfWeek}");
            Console.WriteLine($"dia respecto al año de hoy es {hoy.DayOfYear}");

            DateTime inicioMundial = new DateTime(2018, 6, 14);
            DateTime finMundial = inicioMundial.AddDays(30);
            Console.WriteLine($"La fecha de inicio es {inicioMundial}");
            Console.WriteLine($"La fecha de fin es {finMundial}");

            Console.WriteLine($"La fecha de fin es {finMundial.ToString("yyyy-MM-dddd")}");

            Console.Read();
        }
    }
}
