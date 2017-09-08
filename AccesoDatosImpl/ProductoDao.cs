using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using EntidadesDb;

namespace AccesoDatosImpl
{
    public class ProductoDao : IProductoDao
    {
        public void actualizar(Producto objeto)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                baseDatos.Entry(objeto).State = System.Data.Entity.EntityState.Modified;
                baseDatos.SaveChanges();
            }
        }

        public Producto consultar(int llave)
        {
            Producto producto;
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                producto = baseDatos.Producto.First(e => e.Id == llave);
            }
            return producto;
        }

        public void crear(Producto objeto)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                baseDatos.Producto.Add(objeto);
                baseDatos.SaveChanges();
            }
        }

        public void eliminar(int llave)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                Producto producto = baseDatos.Producto.Find(llave);
                baseDatos.Producto.Remove(producto);
                baseDatos.SaveChanges();
            }
        }

        public ICollection<Producto> listar()
        {
            ICollection<Producto> productos = new List<Producto>();
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                productos = baseDatos.Producto.ToList();
            }
            return productos;
        }
    }
}
