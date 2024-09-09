using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class MenuHuesped
    {
        public void Menu()
        {
            HuespedService service = new HuespedService();
            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Huéspedes ===");
                Console.WriteLine("1. Agregar Huésped");
                Console.WriteLine("2. Eliminar Huésped");
                Console.WriteLine("3. Mostrar Todos los Huéspedes");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            AddHuesped(service);
                            break;
                        case 2:
                            DeleteHuesped(service);
                            break;
                        case 3:
                            VerHuespedes(service);
                            break;
                        case 4:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción inválida, intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor ingrese un número válido.");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();

            } while (option != 4);
        }

        static void AddHuesped(HuespedService service)
        {
            Console.Write("Ingrese la identificación: ");
            string id = Console.ReadLine();

            Console.Write("Ingrese el nombre: ");
            string name = Console.ReadLine();

            Console.Write("Ingrese el número de teléfono: ");
            string phoneNumber = Console.ReadLine();

            Huesped newHuesped = new Huesped
            {
                Id = id,
                Name = name,
                PhoneNumber = phoneNumber
            };

            string result = service.Add(newHuesped);
            Console.WriteLine(result);
        }

        static void DeleteHuesped(HuespedService service)
        {
            Console.Write("Ingrese la identificación del huésped a eliminar: ");
            string id = Console.ReadLine();

            Huesped huesped = new Huesped { Id = id };
            string result = service.Delete(huesped);
            Console.WriteLine(result);
        }

        static void VerHuespedes(HuespedService service)
        {
            var huespedes = service.GetAll();

            if (huespedes != null && huespedes.Count > 0)
            {
                Console.WriteLine("\n=== Lista de Huéspedes ===");
                foreach (var huesped in huespedes)
                {
                    Console.WriteLine($"Identificación: {huesped.Id}");
                    Console.WriteLine($"Nombre: {huesped.Name}");
                    Console.WriteLine($"Teléfono: {huesped.PhoneNumber}");
                    Console.WriteLine("----------------------------");
                }
            }
            else
            {
                Console.WriteLine("No hay huéspedes registrados.");
            }
        }
    }
}
