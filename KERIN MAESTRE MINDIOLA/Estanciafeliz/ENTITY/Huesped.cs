using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Huesped
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string PhoneNumber { get; set; }

        public Huesped()
        {
            
        }
        public Huesped(string name, string id, string phoneNumber)
        {
            Name = name;
            Id = id;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        { 
            return $"{Id};{Name};{PhoneNumber};";
        }

    }
}
