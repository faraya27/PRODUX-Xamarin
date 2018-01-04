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
    public class PedidoController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage SeleccionarPedido()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(PedidoModel.SeleccionarPedidos()), Encoding.UTF8, "application/json");
            return response;
            //return JsonConvert.SerializeObject(PedidoModel.SeleccionarPedidos());
        }

        [HttpGet]
        public HttpResponseMessage SeleccionarPedidoPorCodigo(string codigo)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(PedidoModel.SeleccionarPedidosPorCodigo(codigo)), Encoding.UTF8, "application/json");
            return response;
            //return JsonConvert.SerializeObject(PedidoModel.SeleccionarPedidosPorCodigo(codigo));
        }
        [HttpPost]
        public string InsertarPedido([FromBody]PedidoModel producto)
        {
            return PedidoModel.InsertarPedido(producto);
        }
        [HttpPost]
        public string ActualizarPedido([FromBody]PedidoModel producto)
        {
            return PedidoModel.ActualizarPedido(producto);
        }
        [HttpPost]
        public string EliminarPedido([FromBody]PedidoModel producto)
        {
            return PedidoModel.EliminarPedido(producto);
        }
        [HttpPost]
        public string ConfirmarPedido([FromBody]PedidoModel producto)
        {
            return PedidoModel.ConfirmarPedido(producto);
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