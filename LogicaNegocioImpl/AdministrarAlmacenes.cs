using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesDb;
using AccesoDatos;

namespace LogicaNegocioImpl
{
    public class AdministrarAlmacenes : IAdministrarAlmacenes
    {
        private readonly IAlmacenDao almacenDao;
        public AdministrarAlmacenes(IAlmacenDao almacenDao) {
            this.almacenDao = almacenDao;
        }
        public void actualizar(Almacen almacen)
        {
            almacenDao.actualizar(almacen);
        }

        public Almacen consultar(int idAlmacen)
        {
            return almacenDao.consultar(idAlmacen);
        }

        public void crear(Almacen almacen)
        {
            almacenDao.crear(almacen);
        }

        public void eliminar(int idAlmacen)
        {
            almacenDao.eliminar(idAlmacen);
        }

        public ICollection<Almacen> listar()
        {
            return almacenDao.listar();
        }
    }
}
