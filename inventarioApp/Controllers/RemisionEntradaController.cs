using EntidadesDb;
using inventarioApp.Excepciones;
using LogicaNegocio;
using LogicaNegocio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace inventarioApp.Controllers
{
    [FiltroExceptions]
    public class RemisionEntradaController : ApiController
    {
        private readonly IAdministrarRemisionesEntrada administrarRemisionesEntrada;
        public RemisionEntradaController(IAdministrarRemisionesEntrada administrarRemisionesEntrada) {
            this.administrarRemisionesEntrada = administrarRemisionesEntrada;
        }
        // GET: api/RemisionEntrada
        public IHttpActionResult Get()
        {
            ICollection<ItemListadoRemisionEntradaDto> remisionesEntrada = administrarRemisionesEntrada.listar();
            return Ok(remisionesEntrada);
        }

        // GET: api/RemisionEntrada/5
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        // POST: api/RemisionEntrada
        public IHttpActionResult Post([FromBody]RemisionEntrada value)
        {
            return Ok();
        }

        // PUT: api/RemisionEntrada/5
        public IHttpActionResult Put(int id, [FromBody]RemisionEntrada value)
        {
            return Ok();
        }

        // DELETE: api/RemisionEntrada/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
