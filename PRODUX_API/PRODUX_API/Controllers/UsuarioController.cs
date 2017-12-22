using PRODUX_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRODUX_API.Controllers
{
    public class UsuarioController : ApiController
    {
        public string Autenticar([FromBody]UsuarioModel usuario)
        {
            return UsuarioModel.ValidarUsuarios(usuario.Usuario, usuario.Contrasenna);
            
        }
        public string Autenticar1([FromBody]UsuarioModel usuario)
        {
            return UsuarioModel.ValidarUsuarios(usuario.Usuario, usuario.Contrasenna);

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
        //public void Post([FromBody]string value)
        //{
        //}

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