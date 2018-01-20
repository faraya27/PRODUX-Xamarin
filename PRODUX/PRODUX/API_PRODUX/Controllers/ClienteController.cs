using API_PRODUX.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_PRODUX.Controllers
{
    public class ClienteController : ApiController
    {

        [HttpGet]
        public string SeleccionarClientes()
        {
            return JsonConvert.SerializeObject(ClienteModel.SeleccionarClientes());
        }

        [HttpGet]
        public string SeleccionarClientesPorCodigo(string codigo)
        {
            return JsonConvert.SerializeObject(ClienteModel.SeleccionarClientesPorCodigo(codigo));
        }
        [HttpPost]
        public string InsertarCliente([FromBody]ClienteModel cliente)
        {
            return ClienteModel.InsertarCliente(cliente);
        }
        [HttpPost]
        public string ActualizarUsuario([FromBody]ClienteModel cliente)
        {
            return ClienteModel.ActualizarCliente(cliente);
        }
        [HttpPost]
        public string InactivarUsuario([FromBody]ClienteModel cliente)
        {
            return ClienteModel.InactivarCliente(cliente);
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}