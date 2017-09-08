using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesDb;

namespace LogicaNegocio
{
    public interface IAdministrarProductos
    {
        ICollection<Producto> listar();
        void crear(Producto producto);
        void actualizar(Producto producto);
        Producto consultar(int idProducto);
        void eliminar(int idProducto);
    }
}
