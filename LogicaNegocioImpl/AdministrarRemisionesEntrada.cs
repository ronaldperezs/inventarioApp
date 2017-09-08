using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesDb;
using AccesoDatos;
using LogicaNegocio.Dto;

namespace LogicaNegocioImpl
{
    public class AdministrarRemisionesEntrada : IAdministrarRemisionesEntrada
    {
        private readonly IRemisionesEntradaDao remisionesEntradaDao;
        public AdministrarRemisionesEntrada(IRemisionesEntradaDao remisionesEntradaDao)
        {
            this.remisionesEntradaDao = remisionesEntradaDao;
        }
        public void actualizar(RemisionEntrada remisionEntrada)
        {
            remisionesEntradaDao.actualizar(remisionEntrada);
        }

        public RemisionEntrada consultar(int idRemisionEntrada)
        {
            return remisionesEntradaDao.consultar(idRemisionEntrada);
        }

        public void crear(RemisionEntrada remisionEntrada)
        {
            remisionesEntradaDao.crear(remisionEntrada);
        }

        public void eliminar(int idRemisionEntrada)
        {
            remisionesEntradaDao.eliminar(idRemisionEntrada);
        }

        public ICollection<ItemListadoRemisionEntradaDto> listar()
        {
            ICollection<ItemListadoRemisionEntradaDto> listadoRemisiones = new List<ItemListadoRemisionEntradaDto>();
            ICollection<RemisionEntrada> remisionesEntrada = remisionesEntradaDao.listar();
            foreach(RemisionEntrada remisionEntrada in remisionesEntrada)
            {
                listadoRemisiones.Add(new ItemListadoRemisionEntradaDto()
                {
                    Id = remisionEntrada.Id,
                    Codigo = remisionEntrada.Codigo,
                    FechaDocumento = remisionEntrada.FechaDocumento.ToShortDateString(),
                    Almacen = remisionEntrada.Almacen.Nombre,
                    Proveedor = remisionEntrada.Proveedor.Nombre,
                    IdEstado = remisionEntrada.Estado
                });
            }
            return listadoRemisiones;
        }
    }
}
