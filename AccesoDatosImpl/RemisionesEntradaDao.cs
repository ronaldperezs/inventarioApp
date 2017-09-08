using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntidadesDb;

namespace AccesoDatosImpl
{
    public class RemisionesEntradaDao : IRemisionesEntradaDao
    {
        public void actualizar(RemisionEntrada objeto)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                baseDatos.Entry(objeto).State = System.Data.Entity.EntityState.Modified;
                baseDatos.SaveChanges();
            }
        }

        public RemisionEntrada consultar(int llave)
        {
            RemisionEntrada remisionEntrada;
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                remisionEntrada = baseDatos.RemisionEntrada.First(e => e.Id == llave);
            }
            return remisionEntrada;
        }

        public void crear(RemisionEntrada objeto)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                baseDatos.RemisionEntrada.Add(objeto);
                baseDatos.SaveChanges();
            }
        }

        public void eliminar(int llave)
        {
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                RemisionEntrada remisionEntrada = baseDatos.RemisionEntrada.Find(llave);
                baseDatos.RemisionEntrada.Remove(remisionEntrada);
                baseDatos.SaveChanges();
            }
        }

        public ICollection<RemisionEntrada> listar()
        {
            ICollection<RemisionEntrada> remisionesEntrada = new List<RemisionEntrada>();
            using (PruebaconocimientoConnection baseDatos = new PruebaconocimientoConnection())
            {
                remisionesEntrada = baseDatos.RemisionEntrada.Include(e=>e.Almacen).Include(e=>e.Proveedor).ToList();
            }
            return remisionesEntrada;
        }
    }
}
