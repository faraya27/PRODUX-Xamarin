using API_PRODUX.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace API_PRODUX.Controllers
{
    public class UsuarioController : ApiController
    {


        public string Autenticar([FromBody]UsuarioModel usuario)
        {
            return UsuarioModel.ValidarUsuarios(usuario.Usuario, usuario.Contrasenna);
        }

        [HttpGet]
        public HttpResponseMessage SeleccionarUsuarios()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(UsuarioModel.SeleccionarUsuarios()), Encoding.UTF8, "application/json");
            return response;
            //return JsonConvert.SerializeObject(UsuarioModel.SeleccionarUsuarios());
        }

        [HttpGet]
        public HttpResponseMessage SeleccionarUsuariosPorCodigo(string codigo)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(UsuarioModel.SeleccionarUsuariosPorCodigo(codigo)), Encoding.UTF8, "application/json");
            return response;
            //return JsonConvert.SerializeObject(UsuarioModel.SeleccionarUsuariosPorCodigo(codigo));
        }
        [HttpPost]
        public HttpResponseMessage InsertarUsuario([FromBody]UsuarioModel usuario)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(UsuarioModel.InsertarUsuario(usuario), Encoding.UTF8, "text/plain");
            return response;
           // return UsuarioModel.InsertarUsuario(usuario);
        }
        [HttpPost]
        public HttpResponseMessage ActualizarUsuario([FromBody]UsuarioModel usuario)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(UsuarioModel.ActualizarUsuario(usuario), Encoding.UTF8, "text/plain");
            return response;
            //return UsuarioModel.ActualizarUsuario(usuario);
        }
        [HttpPost]
        public string InactivarUsuario([FromBody]UsuarioModel usuario)
        {
            return UsuarioModel.InactivarUsuario(usuario);
        }
    }
}