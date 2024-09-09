using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class MenuReserva
    {
        public void Menu()
        {
            ReservaService service = new ReservaService();
            int opcionReserva;

            do
            {
                Console.Clear();
                Console.WriteLine("===Gestion De Reservas===");
                Console.WriteLine("1. Agregar una Reserva");
                Console.WriteLine("2. Ver las Reservas");
                Console.WriteLine("3. Eliminar una Reserva");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Seleccione una opción: ");
                opcionReserva = int.Parse(Console.ReadLine());

                switch (opcionReserva)
                {
                    case 1:
                        AgregarReserva(service);
                        break;
                    case 2:
                        VerReservas(service);
                        break;
                    case 3:
                        EliminarReserva(service);
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }

                if (opcionReserva != 4)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcionReserva != 4);
        }

        static void AgregarReserva(ReservaService service)
        {
            Console.Clear();
            Console.WriteLine("Agregar una Nueva Reserva");
            Console.Write("Ingrese la identificación de la reserva: ");
            string idReserva = Console.ReadLine();
            Console.Write("Ingrese la identificación del huésped: ");
            string identificacion = Console.ReadLine();
            var huesped = service.BuscarHuesped(identificacion);
            if(huesped == null)
            {
                Console.WriteLine("No se encontró un huésped con esa identificación.");
                return;
            }
            Console.Write("Ingrese el ID de la habitación: ");
            string idHabitacion = Console.ReadLine();
            var habitacion = service.BuscarHabitacion(idHabitacion);
            if (habitacion == null)
            {
                Console.WriteLine("No se encontró una habitación con ese ID.");
                return;
            }

            Console.Write("Ingrese la fecha de entrada (yyyy-mm-dd): ");
            DateTime fechaEntrada = DateTime.Parse(Console.ReadLine());
            Console.Write("Ingrese la fecha de salida (yyyy-mm-dd): ");
            DateTime fechaSalida = DateTime.Parse(Console.ReadLine());

            Reserva newReserva = new Reserva()
            {
                IdReserva = idReserva,
                huesped = huesped,
                habitacion = habitacion,
                FechaEntrada = fechaEntrada,
                FechaSalida = fechaSalida
            };

            Console.WriteLine("\nReserva registrada correctamente.");
        }

        static void VerReservas(ReservaService service)
        {
            Console.Clear();
            var reservas = service.GetAll();
            if (reservas != null && reservas.Count > 0)
            {
                Console.WriteLine("\n=== Lista de Reservas ===");
                foreach (var hab in reservas)
                {
                    Console.WriteLine($"ID: {hab.IdReserva} | Huesped: {hab.huesped} | Habitacion: {hab.habitacion} | Fecha Entrada: {hab.FechaEntrada}");
                }
            }
            else
            {
                Console.WriteLine("No hay habitaciones registrados.");
            }
        }

        static void EliminarReserva(ReservaService service)
        {
            Console.Clear();
            Console.WriteLine("Eliminar una Reserva");
            Console.Write("Ingrese el ID del huésped para eliminar su reserva: ");
            string idHuesped = Console.ReadLine();

            Reserva reservaAEliminar = reservas.Find(r => r.Identificacion == idHuesped);

            if (reservaAEliminar != null)
            {
                reservas.Remove(reservaAEliminar);
                Console.WriteLine("Reserva eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró una reserva con esa identificación.");
            }
        }
    }
}
