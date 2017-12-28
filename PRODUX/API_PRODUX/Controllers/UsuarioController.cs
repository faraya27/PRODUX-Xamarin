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
        public string SeleccionarUsuarios2(int a)
        {
            return JsonConvert.SerializeObject(UsuarioModel.SeleccionarUsuarios());
        }
    }
}