using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using EntidadesDb;

namespace AccesoDatosImpl
{
    public class ProveedorDao : IProveedorDao
    {
        public void actualizar(Proveedor objeto)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                baseDatos.Entry(objeto).State = System.Data.Entity.EntityState.Modified;
                baseDatos.SaveChanges();
            }
        }

        public Proveedor consultar(int llave)
        {
            Proveedor proveedor;
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                proveedor = baseDatos.Proveedor.First(e=>e.Id==llave);
            }
            return proveedor;
        }

        public void crear(Proveedor objeto)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                baseDatos.Proveedor.Add(objeto);
                baseDatos.SaveChanges();
            }
        }

        public void eliminar(int llave)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                Proveedor proveedor = baseDatos.Proveedor.Find(llave);
                baseDatos.Proveedor.Remove(proveedor);
                baseDatos.SaveChanges();
            }
        }

        public ICollection<Proveedor> listar()
        {
            ICollection<Proveedor> proveedores = new List<Proveedor>();
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection()) {
                proveedores = baseDatos.Proveedor.ToList();
            }
            return proveedores;
        }
    }
}
