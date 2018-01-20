using Newtonsoft.Json;
using PRODUX_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace PRODUX_API.Controllers
{
    public class PedidoLineaController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage SeleccionarPedidoLinea(string codigo)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(PedidoLineaModel.SeleccionarPedidoLinea(codigo)), Encoding.UTF8, "application/json");
            return response;
            //return JsonConvert.SerializeObject(PedidoModel.SeleccionarPedidosPorCodigo(codigo));
        }
        [HttpPost]
        public HttpResponseMessage InsertarPedidoLinea([FromBody]PedidoLineaModel pedido)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(PedidoLineaModel.InsertarPedidoLinea(pedido), Encoding.UTF8, "text/plain");
            return response;
            //return PedidoModel.InsertarPedido(producto);
        }


        [HttpGet]
        public HttpResponseMessage EliminarPedidoLinea(string pedido)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(PedidoLineaModel.EliminarPedidoLinea(pedido)), Encoding.UTF8, "text/plain");
            return response;
            //return JsonConvert.SerializeObject(PedidoModel.SeleccionarPedidosPorCodigo(codigo));
        }
        //[HttpPost]
        //public HttpResponseMessage EliminarPedidoLinea([FromBody]string pedido)
        //{
        //    var response = Request.CreateResponse(HttpStatusCode.OK);
        //    response.Content = new StringContent(PedidoLineaModel.EliminarPedidoLinea(pedido), Encoding.UTF8, "text/plain");
        //    return response;
        //    //return PedidoModel.InsertarPedido(producto);
        //}

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