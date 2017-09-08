using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntidadesDb;
using inventarioApp.Excepciones;
using LogicaNegocio;

namespace inventarioApp.Controllers
{
    [FiltroExceptions]
    public class ProveedorController : ApiController
    {
        private readonly IAdministrarProveedores administrarProveedores;
        public ProveedorController(IAdministrarProveedores administrarProveedores) {
            this.administrarProveedores = administrarProveedores;
        }
        // GET: api/Proveedor
        public IHttpActionResult Get()
        {
            ICollection<Proveedor> proveedores = administrarProveedores.listar();
            return Ok(proveedores);
        }

        // GET: api/Proveedor/5
        public IHttpActionResult Get(int id)
        {
            Proveedor proveedor = administrarProveedores.consultar(id);
            return Ok(proveedor);
        }

        // POST: api/Proveedor
        public IHttpActionResult Post([FromBody]Proveedor value)
        {
            administrarProveedores.crear(value);
            return Ok();
        }

        // PUT: api/Proveedor/5
        public IHttpActionResult Put([FromBody]Proveedor value)
        {
            administrarProveedores.actualizar(value);
            return Ok();
        }

        // DELETE: api/Proveedor/5
        public IHttpActionResult Delete(int id)
        {
            administrarProveedores.eliminar(id);
            return Ok();
        }
    }
}
