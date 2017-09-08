using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesDb;

namespace AccesoDatos
{
    public interface IProductoDao : ICrudDao<Producto,int>
    {
    }
}
