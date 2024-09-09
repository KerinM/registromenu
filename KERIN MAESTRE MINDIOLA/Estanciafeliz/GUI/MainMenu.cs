using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class MainMenu
    {
        public void MenuPrincipal()
        {
            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Gestión de Huéspedes y Reservas ===");
                Console.WriteLine("1. Registro de Huésped");
                Console.WriteLine("2. Registro de Reserva");
                Console.WriteLine("3. Gestion de Habitacion");
                Console.WriteLine("4. Cálculo del Costo Total de la Estancia");
                Console.WriteLine("5. Verificación de Disponibilidad de Habitaciones");
                Console.WriteLine("6. Visualización de Reservas");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            RegistrarHuesped();
                            break;
                        case 2:
                            RegistrarReserva();
                            break;
                        case 3:
                            GestionHabitacion();
                            break;
                        case 4:
                            CalcularCostoEstancia();
                            break;
                        case 5:
                            VerificarDisponibilidad();
                            break;
                        case 6:
                            VisualizarReservas();
                            break;
                        case 7:
                            Console.WriteLine("Saliendo del sistema...");
                            break;
                        default:
                            Console.WriteLine("Opción inválida, por favor intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor ingrese un número válido.");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();

            } while (option != 7);
        }

        private void RegistrarHuesped()
        {
            new MenuHuesped().Menu();
        }
        private void RegistrarReserva()
        {
            throw new NotImplementedException();
        }
        private void GestionHabitacion()
        {
            new MenuHabitacion().Menu();
        }
        private void VerificarDisponibilidad()
        {
            throw new NotImplementedException();
        }

        private void CalcularCostoEstancia()
        {
            throw new NotImplementedException();
        }

        private void VisualizarReservas()
        {
            throw new NotImplementedException();
        }
    }
}
