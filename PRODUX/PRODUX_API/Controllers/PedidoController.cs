using API_PRODUX.Models;
using Newtonsoft.Json;
using PRODUX_API.Models;
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
        public HttpResponseMessage InsertarPedido([FromBody]PedidoModel pedido)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(PedidoModel.InsertarPedido(pedido), Encoding.UTF8, "text/plain");
            return response;
            //return PedidoModel.InsertarPedido(producto);
        }
        [HttpPost]
        public HttpResponseMessage ActualizarPedido([FromBody]PedidoModel pedido)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(PedidoModel.ActualizarPedido(pedido), Encoding.UTF8, "text/plain");
            return response;
            //return PedidoModel.ActualizarPedido(producto);
        }
        [HttpPost]
        public HttpResponseMessage EliminarPedido([FromBody]PedidoModel pedido)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(PedidoModel.EliminarPedido(pedido), Encoding.UTF8, "text/plain");
            return response;
           // return PedidoModel.EliminarPedido(producto);
        }
        [HttpPost]
        public HttpResponseMessage ConfirmarPedido([FromBody]PedidoModel pedido)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(PedidoModel.ConfirmarPedido(pedido), Encoding.UTF8, "text/plain");
            return response;
            //return PedidoModel.ConfirmarPedido(producto);
        }

        [HttpGet]
        public HttpResponseMessage SeleccionarPedidoLinea(string IdPedido)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(PedidoLineaModel.SeleccionarPedidoLinea(IdPedido)), Encoding.UTF8, "application/json");
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
        [HttpPost]
        public HttpResponseMessage ActualizarPedidoLinea([FromBody]PedidoLineaModel pedido)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(PedidoLineaModel.ActualizarPedidoLinea(pedido), Encoding.UTF8, "text/plain");
            return response;
            //return PedidoModel.ActualizarPedido(producto);
        }
        [HttpPost]
        public HttpResponseMessage EliminarPedidoLinea([FromBody]PedidoLineaModel pedido)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(PedidoLineaModel.EliminarPedidoLinea(pedido), Encoding.UTF8, "text/plain");
            return response;
            // return PedidoModel.EliminarPedido(producto);
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