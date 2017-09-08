using EntidadesDb;
using LogicaNegocio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public interface IAdministrarRemisionesEntrada
    {
        ICollection<ItemListadoRemisionEntradaDto> listar();
        void crear(RemisionEntrada remisionEntrada);
        void actualizar(RemisionEntrada remisionEntrada);
        RemisionEntrada consultar(int idRemisionEntrada);
        void eliminar(int idRemisionEntrada);
    }
}
