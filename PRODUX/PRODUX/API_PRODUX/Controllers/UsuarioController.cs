using API_PRODUX.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public string SeleccionarUsuarios()
        {
            return JsonConvert.SerializeObject(UsuarioModel.SeleccionarUsuarios());
        }

        [HttpGet]
        public string SeleccionarUsuariosPorCodigo(string codigo)
        {
            return JsonConvert.SerializeObject(UsuarioModel.SeleccionarUsuariosPorCodigo(codigo));
        }
        [HttpPost]
        public string InsertarUsuario([FromBody]UsuarioModel usuario)
        {
             return UsuarioModel.InsertarUsuario(usuario);
        }
        [HttpPost]
        public string ActualizarUsuario([FromBody]UsuarioModel usuario)
        {
            return UsuarioModel.ActualizarUsuario(usuario);
        }
        [HttpPost]
        public string InactivarUsuario([FromBody]UsuarioModel usuario)
        {
            return UsuarioModel.InactivarUsuario(usuario);
        }
    }
}