using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using EntidadesDb;
using LogicaNegocio;

namespace LogicaNegocioImpl
{
    public class AdministrarProveedores : IAdministrarProveedores
    {
        private readonly IProveedorDao proveedorDao;
        public AdministrarProveedores(IProveedorDao proveedorDao)
        {
            this.proveedorDao = proveedorDao;
        }
        public void actualizar(Proveedor proveedor)
        {
            proveedorDao.actualizar(proveedor);
        }

        public Proveedor consultar(int idProveedor)
        {
            return proveedorDao.consultar(idProveedor);
        }

        public void crear(Proveedor proveedor)
        {
            proveedorDao.crear(proveedor);
        }

        public void eliminar(int idProveedor)
        {
            proveedorDao.eliminar(idProveedor);
        }

        public ICollection<Proveedor> listar()
        {
            return proveedorDao.listar();
        }
    }
}
