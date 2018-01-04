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
    public class ProductoController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage SeleccionarProductos()
        {

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(ProductoModel.SeleccionarProductos()), Encoding.UTF8, "application/json");
            return response;
            //return JsonConvert.SerializeObject(ProductoModel.SeleccionarProductos());
        }

        [HttpGet]
        public HttpResponseMessage SeleccionarProductoPorCodigo(string codigo)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(ProductoModel.SeleccionarProductosPorCodigo(codigo)), Encoding.UTF8, "application/json");
            return response;
            //return JsonConvert.SerializeObject(ProductoModel.SeleccionarProductosPorCodigo(codigo));
        }
        [HttpPost]
        public string InsertarProducto([FromBody]ProductoModel producto)
        {
            return ProductoModel.InsertarProducto(producto);
        }
        [HttpPost]
        public string ActualizarProducto([FromBody]ProductoModel producto)
        {
           return ProductoModel.ActualizarProducto(producto);
        }
        [HttpPost]
        public string EliminarProducto([FromBody]ProductoModel producto)
        {
            return ProductoModel.EliminarProducto(producto);
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