using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReservaService
    {
        private ReservaRepository repository;
        private List<Reserva> reservas;
        private HuespedRepository huespedRepository;
        private HabitacionRepository habitacionRepository;

        public ReservaService()
        {
            repository = new ReservaRepository(Config.FILENAME_RESERVAS);
            huespedRepository = new HuespedRepository(Config.FILENAME_HUESPEDES);
            habitacionRepository = new HabitacionRepository(Config.FILENAME_HABITACIONES);
        }

        public Huesped BuscarHuesped(string idHuesped)
        {
            return huespedRepository.FindById(idHuesped);
        }

        public Habitacion BuscarHabitacion(string idHabitacion)
        {
            return habitacionRepository.BuscarHabitacion(idHabitacion);
        }

        public string Add(Reserva entidad)
        {
            if (string.IsNullOrWhiteSpace(entidad.IdReserva))
            {
                return "La identificación no puede estar vacía.";
            }

            if (string.IsNullOrWhiteSpace(entidad.huesped.Id))
            {
                return "La identifacion de huesped no puede estar vacío.";
            }

            if (string.IsNullOrWhiteSpace(entidad.habitacion.Id))
            {
                return "La identificación de la habitación no puede estar vacía.";
            }

            if (entidad.FechaEntrada >= entidad.FechaSalida)
            {
                return "La fecha de salida debe ser posterior a la fecha de entrada.";
            }

            reservas = repository.LoadData();
            if (reservas.Exists(r => r.IdReserva == entidad.IdReserva))
            {
                return "Ya existe una reserva con esa identificación.";
            }

            var huesped = huespedRepository.LoadData().Find(h => h.Id == entidad.huesped.Id);
            if (huesped == null)
            {
                return $"No se encontró un huésped con la identificación {entidad.huesped.Id}.";
            }

            var habitacion = habitacionRepository.LoadData().Find(h => h.Id == entidad.habitacion.Id);
            if (habitacion == null)
            {
                return $"No se encontró una habitación con la identificación {entidad.habitacion.Id}.";
            }

            entidad.huesped = huesped;
            entidad.habitacion = habitacion;

            repository.SaveData(entidad);
            return $"Reserva añadida:\n" +
                   $"ID Reserva: {entidad.IdReserva}\n" +
                   $"Huésped: ID: {huesped.Id})\n" +
                   $"Habitación: {habitacion.Id}\n" +
                   $"Fechas: {entidad.FechaEntrada.ToString("yyyy-MM-dd")} - {entidad.FechaSalida.ToString("yyyy-MM-dd")}";
        }

        public string Delete(Reserva entidad)
        {
            if (string.IsNullOrWhiteSpace(entidad.IdReserva))
            {
                return "La identificación del huésped no puede estar vacía.";
            }
            return repository.Delete(entidad);
        }

        public List<Reserva> GetAll()
        {
            reservas = repository.LoadData();
            return reservas;
        }
    }
}
