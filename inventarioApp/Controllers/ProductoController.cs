using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntidadesDb;
using LogicaNegocio;
using inventarioApp.Excepciones;

namespace inventarioApp.Controllers
{
    [FiltroExceptions]
    public class ProductoController : ApiController
    {
        private readonly IAdministrarProductos administrarProductos;
        public ProductoController(IAdministrarProductos administrarProductos) {
            this.administrarProductos = administrarProductos;
        }
        // GET: api/Producto
        public IHttpActionResult Get()
        {
            ICollection<Producto> productos = administrarProductos.listar();
            return Ok(productos);
        }

        // GET: api/Producto/5
        public IHttpActionResult Get(int id)
        {
            Producto producto = administrarProductos.consultar(id);
            return Ok(producto);
        }

        // POST: api/Producto
        public IHttpActionResult Post([FromBody]Producto value)
        {
            administrarProductos.crear(value);
            return Ok();
        }

        // PUT: api/Producto/5
        public IHttpActionResult Put([FromBody]Producto value)
        {
            administrarProductos.actualizar(value);
            return Ok();
        }

        // DELETE: api/Producto/5
        public IHttpActionResult Delete(int id)
        {
            administrarProductos.eliminar(id);
            return Ok();
        }
    }
}
