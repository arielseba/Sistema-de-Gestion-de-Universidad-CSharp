using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_2
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|      Sistema de Gestión de Universidad        |");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("\n[A] - Registrar Docentes en la Universidad.");
            Console.WriteLine("\n[B] - Listar Docentes de la Universidad.");
            Console.WriteLine("\n[C] - Registrar Alumnos a la Universidad.");
            Console.WriteLine("\n[D] - Listar Alumnos de la Universidad.");
            Console.WriteLine("\n[E] - Registrar Comisiones de la Universidad.");
            Console.WriteLine("\n[F] - Listar Comisiones de la Universidad.");
            Console.WriteLine("\n[G] - Asignar un Alumno a una Comision.");
            Console.WriteLine("\n[H] - Asignar un Docente a una Comision.");
            Console.WriteLine("\n[I] - Remover un Alumno de una Comision.");
            Console.WriteLine("\n[J] - Remover un Docente de una Comision.");
            Console.WriteLine("\n[K] - Remover un Alumno de la Universidad.");
            Console.WriteLine("\n[L] - Remover un Docente de la Universidad.");
            Console.WriteLine("\n[M] - Listar Docentes de una Comision.");
            Console.WriteLine("\n[N] - Listar Alumnos de una Comision.");
            Console.WriteLine("\n[O] - Buscar Alumno/Docente por numero de legajo.");
            Console.WriteLine("\n[S] - Salir.");
            Console.WriteLine("\n_________________________________________________");
            return CInterfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("Error. " + nombDato + "es obligatorio:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();

        }
        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Presione enter para continuar>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
