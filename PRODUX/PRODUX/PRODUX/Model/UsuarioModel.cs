using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PRODUX.Model
{
    public class UsuarioModel
    {
        public UsuarioModel() { }

        public async Task<string> Autenticar(string usuario, string contrasena)
        {
            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri(""); //Direccion de mi API

                var json = JsonConvert.SerializeObject(new { Usuario = usuario, Contrasenna = contrasena }); //Esto es un string

                var content = new StringContent(json, Encoding.UTF8, "appliication/json");

                HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false); //Esto se puede obviar ConfigureAwait(false)

                string ans = await response.Content.ReadAsStringAsync();

                //UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(ans)

                return ans;
            }            
        }
    }
}
