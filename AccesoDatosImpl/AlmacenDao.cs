using AccesoDatos;
using EntidadesDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosImpl
{
    public class AlmacenDao : IAlmacenDao
    {
        public void actualizar(Almacen objeto)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                baseDatos.Entry(objeto).State = System.Data.Entity.EntityState.Modified;
                baseDatos.SaveChanges();
            }
        }

        public Almacen consultar(int llave)
        {
            Almacen almacen;
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                almacen = baseDatos.Almacen.First(e => e.Id == llave);
            }
            return almacen;
        }

        public void crear(Almacen objeto)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                baseDatos.Almacen.Add(objeto);
                baseDatos.SaveChanges();
            }
        }

        public void eliminar(int llave)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                Almacen almacen = baseDatos.Almacen.Find(llave);
                baseDatos.Almacen.Remove(almacen);
                baseDatos.SaveChanges();
            }
        }

        public ICollection<Almacen> listar()
        {
            ICollection<Almacen> almacenes = new List<Almacen>();
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                almacenes = baseDatos.Almacen.ToList();
            }
            return almacenes;
        }
    }
}
