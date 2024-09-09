using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HuespedRepository : BaseRepository<Huesped>
    {
        public HuespedRepository(string fileName) : base(fileName) 
        { 
        }

        public override List<Huesped> LoadData()
        {
            try
            {
                List<Huesped> huespedes = new List<Huesped>();
                string line;
                StreamReader reader = new StreamReader(_fileName);
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    huespedes.Add(Map(line));
                }
                reader.Close();
                return huespedes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string Delete(Huesped entidad)
        {
            List<Huesped> huespuedes = LoadData();
            if(huespuedes == null || !huespuedes.Any())
            {
                return "No hay datos de huéspedes disponibles.";
            }
            Huesped huespedEliminar = huespuedes.FirstOrDefault(h => h.Id == entidad.Id);
            if (huespedEliminar == null)
            {
                return "El huésped con la identificación especificada no existe.";
            }

            huespuedes.Remove(huespedEliminar);

            UpdateHuespuedes(huespuedes);

            return "Huésped eliminado con éxito.";
        }

        private string UpdateHuespuedes(List<Huesped> huspuedes)
        {
            try
            {
                StreamWriter writer = new StreamWriter(Config.FILENAME_HUESPEDES, false);
                foreach (var hue in huspuedes)
                {
                    string line = $"{hue.Id};{hue.Name};{hue.PhoneNumber}";
                    writer.WriteLine(line);
                }
                writer.Close();
                return "Datos actualizados correctamente";
            }
            catch (Exception ex)
            {
                return "Error al guardar los datos: " + ex.Message;
            }
        }
        public Huesped FindById(string id)
        {
            List<Huesped> huespedes = LoadData();
            if (huespedes == null || !huespedes.Any())
            {
                return null;
            }

            Huesped huespedEncontrado = huespedes.FirstOrDefault(r => r.Id == id);
            return huespedEncontrado;
        }

        private Huesped Map(string line)
        {
            Huesped huesped = new Huesped();
            huesped.Id = line.Split(';')[0];
            huesped.Name = line.Split(';')[1];
            huesped.PhoneNumber = line.Split(';')[2];
            return huesped;
        }
    }
}
