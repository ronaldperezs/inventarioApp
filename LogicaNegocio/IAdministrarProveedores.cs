using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesDb;

namespace LogicaNegocio
{
    public interface IAdministrarProveedores
    {
        ICollection<Proveedor> listar();
        void crear(Proveedor proveedor);
        void actualizar(Proveedor proveedor);
        Proveedor consultar(int idProveedor);
        void eliminar(int idProveedor);
    }
}
