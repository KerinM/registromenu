using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICrud<T>
    {
        string Add(T entidad);
        string Delete(T entidad);
        List<T> GetAll();
    }
}
