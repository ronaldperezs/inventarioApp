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
    public class AdministrarProductos : IAdministrarProductos
    {
        private readonly IProductoDao productoDao;
        public AdministrarProductos(IProductoDao productoDao)
        {
            this.productoDao = productoDao;
        }
        public void actualizar(Producto producto)
        {
            productoDao.actualizar(producto);
        }

        public Producto consultar(int idProducto)
        {
            return productoDao.consultar(idProducto);
        }

        public void crear(Producto producto)
        {
            productoDao.crear(producto);
        }

        public void eliminar(int idProducto)
        {
            productoDao.eliminar(idProducto);
        }

        public ICollection<Producto> listar()
        {
            return productoDao.listar();
        }
    }
}
