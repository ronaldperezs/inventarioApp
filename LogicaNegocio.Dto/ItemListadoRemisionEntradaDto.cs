using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dto
{
    public class ItemListadoRemisionEntradaDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string FechaDocumento { get; set; }
        public string Proveedor { get; set; }
        public string Almacen { get; set; }
        public int IdEstado { get; set; }
    }
}
