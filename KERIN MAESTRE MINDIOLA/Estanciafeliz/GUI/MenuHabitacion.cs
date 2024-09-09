using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class MenuHabitacion
    {
        public void Menu()
        {
            HabitacionService service = new HabitacionService();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Menú de Gestión de Habitaciones ===");
                Console.WriteLine("1. Ver Habitaciones");
                Console.WriteLine("2. Agregar Habitación");
                Console.WriteLine("3. Eliminar Habitación");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        VerHabitaciones(service);
                        break;
                    case 2:
                        AgregarHabitacion(service);
                        break;
                    case 3:
                        EliminarHabitacion(service);
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }

                if (opcion != 4)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 4);
        }

        static void AgregarHabitacion(HabitacionService service)
        {
            Console.Clear();
            Console.WriteLine("=== Agregar Habitación ===");
            Console.Write("Ingrese ID de Habitación: ");
            string id = Console.ReadLine();

            Console.Write("Ingrese Categoría (Economica, Estandar, Suite): ");
            string categoria = Console.ReadLine();

            Console.Write("Ingrese Precio por Noche: ");
            double precio = double.Parse(Console.ReadLine());

            Habitacion newHabitacion = new Habitacion()
            {
                Id = id,
                Categoria = categoria,
                Costo = precio
            };

            string result = service.Add(newHabitacion);
            Console.WriteLine(result);

        }
        static void EliminarHabitacion(HabitacionService service)
        {
            throw new NotImplementedException();
        }

        static void VerHabitaciones(HabitacionService service)
        {
            Console.Clear();
            var habitaciones = service.GetAll();
            if (habitaciones != null && habitaciones.Count > 0)
            {
                Console.WriteLine("\n=== Lista de Habitaciones ===");
                foreach (var hab in habitaciones)
                {
                    Console.WriteLine($"ID: {hab.Id} | Categoría: {hab.Categoria} | Precio por Noche: ${hab.Costo:N0}");
                }
            }
            else
            {
                Console.WriteLine("No hay habitaciones registrados.");
            }
        }
    }
}
