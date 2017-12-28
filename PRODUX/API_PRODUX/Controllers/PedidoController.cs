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
    public class PedidoController : ApiController
    {

        [HttpGet]
        public string SeleccionarPedido()
        {
            return JsonConvert.SerializeObject(PedidoModel.SeleccionarPedido());
        }

        [HttpGet]
        public string SeleccionarPedidoPorCodigo(string codigo)
        {
            return JsonConvert.SerializeObject(PedidoModel.SeleccionarPedidoPorCodigo(codigo));
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