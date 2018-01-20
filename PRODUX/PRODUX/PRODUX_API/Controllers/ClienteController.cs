using API_PRODUX.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace API_PRODUX.Controllers
{
    public class ClienteController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage SeleccionarClientes()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(ClienteModel.SeleccionarClientes()), Encoding.UTF8, "application/json");
            return response;
            //return JsonConvert.SerializeObject(ClienteModel.SeleccionarClientes());
        }

        [HttpGet]
        public HttpResponseMessage SeleccionarClientesActivos()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(ClienteModel.SeleccionarClientesActivos()), Encoding.UTF8, "application/json");
            return response;
            //return JsonConvert.SerializeObject(ClienteModel.SeleccionarClientes());
        }

        [HttpGet]
        public HttpResponseMessage SeleccionarClientesPorCodigo(string codigo)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(ClienteModel.SeleccionarClientesPorCodigo(codigo)), Encoding.UTF8, "application/json");
            return response;
            //return JsonConvert.SerializeObject(ClienteModel.SeleccionarClientesPorCodigo(codigo));
        }
        [HttpPost]
        public HttpResponseMessage InsertarCliente([FromBody]ClienteModel cliente)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(ClienteModel.InsertarCliente(cliente), Encoding.UTF8, "text/plain");
            return response;
           // return ClienteModel.InsertarCliente(cliente);
        }
        [HttpPost]
        public HttpResponseMessage ActualizarCLiente([FromBody]ClienteModel cliente)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(ClienteModel.ActualizarCliente(cliente), Encoding.UTF8, "text/plain");
            return response;
            //return ClienteModel.ActualizarCliente(cliente);
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