using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedica
{
    internal class Interfaz
    {
        static Interfaz()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("************************************************");
            Console.WriteLine("*     Sistema de Gestión de Empresa Medica     *");
            Console.WriteLine("************************************************");
            Console.WriteLine("\n[A] Registrar un empleado.");
            Console.WriteLine("\n[B] Registrar un vehiculo.");
            Console.WriteLine("\n[C] Registrar una dotación.");
            Console.WriteLine("\n[D] Mostrar todos los empleados.");
            Console.WriteLine("\n[E] Mostrar todos los vehiculos.");
            Console.WriteLine("\n[F] Mostrar todas las dotaciones.");
            Console.WriteLine("\n[G] Eliminar empleado");
            Console.WriteLine("\n[H] Mostrar datos completos de un empleado.");
            Console.WriteLine("\n[I] Mostrar datos completos de una dotacion.");

            Console.WriteLine("\n[S] Salir de la aplicación.");
            Console.WriteLine("\n**********************************************");
            return Interfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + "es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();

        }
        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
