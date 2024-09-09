using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HuespedService : ICrud<Huesped>
    {
        private HuespedRepository repository;
        private List<Huesped> huespedes;

        public HuespedService()
        {
            repository = new HuespedRepository(Config.FILENAME_HUESPEDES);
        }
        public string Add(Huesped entidad)
        {
            if (string.IsNullOrWhiteSpace(entidad.Id))
            {
                return "La identificación no puede estar vacía.";
            }

            if (string.IsNullOrWhiteSpace(entidad.Name))
            {
                return "El nombre no puede estar vacío.";
            }

            if (string.IsNullOrWhiteSpace(entidad.PhoneNumber) || entidad.PhoneNumber.Length > 15)
            {
                return "El número de teléfono debe contener solo números y no superar 15 caracteres.";
            }

            repository.SaveData(entidad);
            return $"Huespued añadido:" +
                "\n" + entidad.Name + "\n" + entidad.Id;
        }

        public string Delete(Huesped entidad)
        {
            if (string.IsNullOrWhiteSpace(entidad.Id))
            {
                return "La identificación del huésped no puede estar vacía.";
            }
           return repository.Delete(entidad);
        }

        public Huesped GetById(string id) 
        {
            return repository.FindById(id);
        }

        public List<Huesped> GetAll()
        {
            huespedes = repository.LoadData();
            return huespedes;
        }
    }
}
