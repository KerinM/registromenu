using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Habitacion
    {
        public string Id {  get; set; }
        public double Costo { get; set; }
        public string Categoria {  get; set; }

        public Habitacion() 
        {
        }

        public Habitacion(double costo, string categoria)
        {
            Costo = costo;
            Categoria = categoria;
        }

        public override string ToString() 
        {
            return $"{Id};{Categoria};{Costo}";
        }

    }
}
