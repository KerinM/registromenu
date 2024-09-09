using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Reserva
    {
        public string IdReserva{get; set;}  
        public Huesped huesped {  get; set; }
        public Habitacion habitacion { get; set; }
        public DateTime FechaEntrada { get; set; } 
        public DateTime FechaSalida { get; set; }
        public double CostoEstancia {  get; set; }
        public Reserva()
        {
            
        }
        public Reserva(string idReserva, Huesped huesped, Habitacion habitacion, DateTime fechaEntrada, DateTime fechaSalida)
        {
            IdReserva = idReserva;
            this.huesped = huesped;
            this.habitacion = habitacion;
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
        }

        public override string ToString()
        {
            return "";
        }

    }
}
