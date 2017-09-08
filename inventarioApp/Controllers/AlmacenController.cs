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
    public class AlmacenController : ApiController
    {
        private readonly IAdministrarAlmacenes administrarAlmacenes;
        public AlmacenController(IAdministrarAlmacenes administrarAlmacenes) {
            this.administrarAlmacenes = administrarAlmacenes;
        }
        // GET: api/Producto
        public IHttpActionResult Get()
        {
            ICollection<Almacen> productos = administrarAlmacenes.listar();
            return Ok(productos);
        }

        // GET: api/Producto/5
        public IHttpActionResult Get(int id)
        {
            Almacen producto = administrarAlmacenes.consultar(id);
            return Ok(producto);
        }

        // POST: api/Producto
        public IHttpActionResult Post([FromBody]Almacen value)
        {
            administrarAlmacenes.crear(value);
            return Ok();
        }

        // PUT: api/Producto/5
        public IHttpActionResult Put([FromBody]Almacen value)
        {
            administrarAlmacenes.actualizar(value);
            return Ok();
        }

        // DELETE: api/Producto/5
        public IHttpActionResult Delete(int id)
        {
            administrarAlmacenes.eliminar(id);
            return Ok();
        }
    }
}
