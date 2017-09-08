using EntidadesDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public interface IAdministrarAlmacenes
    {
        ICollection<Almacen> listar();
        void crear(Almacen almacen);
        void actualizar(Almacen almacen);
        Almacen consultar(int idAlmacen);
        void eliminar(int idAlmacen);
    }
}
