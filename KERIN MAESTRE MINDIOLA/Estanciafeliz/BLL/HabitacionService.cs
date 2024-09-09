using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HabitacionService
    {
        private HabitacionRepository repository;
        private List<Habitacion> habitaciones;

        public HabitacionService()
        {
            repository = new HabitacionRepository(Config.FILENAME_HABITACIONES);
        }

        public string Add(Habitacion entidad)
        {
            if (string.IsNullOrWhiteSpace(entidad.Id))
            {
                return "La identificación no puede estar vacía.";
            }

            if (string.IsNullOrWhiteSpace(entidad.Categoria))
            {
                return "El nombre no puede estar vacío.";
            }

            repository.SaveData(entidad);
            return $"Habitacion añadido:" +
                "\n" + entidad.Id + "\n" + entidad.Categoria;
        }

        /*public string Delete(Huesped entidad)
        {
            if (string.IsNullOrWhiteSpace(entidad.Id))
            {
                return "La identificación del huésped no puede estar vacía.";
            }
            return repository.Delete(entidad);
        }*/

        public List<Habitacion> GetAll()
        {
            habitaciones = repository.LoadData();
            return habitaciones;
        }
    }
}
