using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HabitacionRepository : BaseRepository<Habitacion>
    {
        public HabitacionRepository(string fileName) : base(fileName)
        {
        }

        public override List<Habitacion> LoadData()
        {
            try
            {
                List<Habitacion> habitaciones = new List<Habitacion>();
                string line;
                StreamReader reader = new StreamReader(_fileName);
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    habitaciones.Add(Map(line));
                }
                reader.Close();
                return habitaciones;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Habitacion BuscarHabitacion(string id)
        {
            List<Habitacion> habitaciones = LoadData();
            return habitaciones.FirstOrDefault(h => h.Id == id);
        }

        private Habitacion Map(string line)
        {
            Habitacion habitacion = new Habitacion();
            habitacion.Id = line.Split(';')[0];
            habitacion.Categoria = line.Split(';')[1];
            habitacion.Costo = double.Parse(line.Split(';')[2]);
            return habitacion;
        }
    }
}
