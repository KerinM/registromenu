using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReservaRepository : BaseRepository<Reserva>
    { 
        public ReservaRepository(string fileName) : base(fileName)
        {

        }
        public override List<Reserva> LoadData()
        {
            try
            {
                List<Reserva> reservas = new List<Reserva>();
                string line;
                StreamReader reader = new StreamReader(_fileName);
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    reservas.Add(Map(line));
                }
                reader.Close();
                return reservas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Delete(Reserva entidad)
        {
            List<Reserva> reservas = LoadData();
            if (reservas == null || !reservas.Any())
            {
                return "No hay datos de huéspedes disponibles.";
            }
            Reserva reservaEliminar = reservas.FirstOrDefault(h => h.IdReserva == entidad.IdReserva);
            if (reservaEliminar == null)
            {
                return "El huésped con la identificación especificada no existe.";
            }

            reservas.Remove(reservaEliminar);

            UpdateReservas(reservas);

            return "Reserva eliminada con éxito.";
        }

        private string UpdateReservas(List<Reserva> reservas)
        {
            try
            {
                StreamWriter writer = new StreamWriter(Config.FILENAME_RESERVAS, false);
                foreach (var res in reservas)
                {
                    string line = $"{res.IdReserva};{res.huesped.Id};{res.habitacion.Id};{res.FechaEntrada:yyyy-MM-dd};{res.FechaSalida:yyyy - MM - dd}";
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

        private Reserva Map(string line)
        {
            Reserva reserva = new Reserva();
            reserva.IdReserva = line.Split(';')[0];
            reserva.huesped = new Huesped { Id = line.Split(';')[1]};
            reserva.habitacion = new Habitacion { Id = line.Split(';')[2] };
            reserva.FechaEntrada = DateTime.Parse(line.Split(';')[3]);
            reserva.FechaSalida = DateTime.Parse(line.Split(';')[4]);
            return reserva;
        }
    }
}
