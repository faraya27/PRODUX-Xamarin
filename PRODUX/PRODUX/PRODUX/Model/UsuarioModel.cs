using Newtonsoft.Json;
using Realms;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.IO;
using System.Collections.ObjectModel;

namespace PRODUX.Model
{
    public class UsuarioModel /*: RealmObject*/
    {
        public UsuarioModel() {
            //var realm = Realm.GetInstance();

            //var usuarios = realm.All<UsuarioModel>.Where(p => p.Usuario = "Fabian");
        }

        #region Propiedades

        public string Usuario { get; set; }

        public string Contrasenna { get; set; }

        public int Estado { get; set; }

        public string Usuario_Creacion { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        #endregion

        #region Métodos

        public static async Task<string> Autenticar(UsuarioModel usuario)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Usuario() + "autenticar"); //Direccion de mi API

                    //var json = JsonConvert.SerializeObject(new { Usuario = usuario.Usuario, Contrasenna = usuario.Contrasenna, Estado = usuario.Estado, Usuario_Creacion = usuario.Usuario_Creacion }); //Esto es un string
                    var json = JsonConvert.SerializeObject(
                                                            new {
                                                                    Usuario = usuario.Usuario,
                                                                    Contrasenna = usuario.Contrasenna
                                                                }
                                                            ); //Esto es un string

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    //HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false); //Esto se puede obviar ConfigureAwait(false)
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    //UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(ans)

                    return resultado;
                }


                //var request = (HttpWebRequest)WebRequest.Create("https://152b4592.ngrok.io/api/prueba");

                //var json = JsonConvert.SerializeObject(new { Usuario = usuario.Usuario, Contrasenna = usuario.Contrasenna });
                //var data = Encoding.UTF8.GetBytes(json);

                //request.Method = "POST";
                //request.ContentType = "application/json";
                //request.ContentLength = data.Length;

                //using (var stream = request.GetRequestStream())
                //{
                //    stream.Write(data, 0, data.Length);
                //}

                //var response = (HttpWebResponse)request.GetResponse();

                //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return "";
            }
            catch (WebException wex)
            {
                throw wex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
                        
        }

        public static async Task<ObservableCollection<UsuarioModel>> SeleccionarTodos()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Usuario() + "SeleccionarUsuarios"); 
                    
                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ObservableCollection<UsuarioModel>>(resultado);
                }
            }
            catch (WebException wex)
            {
                throw wex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static async Task<UsuarioModel> SeleccionarPorCodigo()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Usuario() + "SeleccionarUsuariosPorCodigo");

                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<UsuarioModel>(resultado);
                }
            }
            catch (WebException wex)
            {
                throw wex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static async Task<string> Insertar(UsuarioModel usuario)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Usuario() + "InsertarUsuario");
                    
                    var json = JsonConvert.SerializeObject(
                                                            new {
                                                                    Usuario = usuario.Usuario,
                                                                    Contrasenna = usuario.Contrasenna,
                                                                    Estado = usuario.Estado,
                                                                    Usuario_Creacion = usuario.Usuario_Creacion,
                                                                    Fecha_Creacion = usuario.Fecha_Creacion
                                                                }
                                                            );

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return resultado;
                }
            }
            catch (WebException wex)
            {
                throw wex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static async Task<string> Actualizar(UsuarioModel usuario)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Usuario() + "ActualizarUsuarioInactivarUsuario");

                    var json = JsonConvert.SerializeObject(
                                                            new {
                                                                    Usuario = usuario.Usuario,
                                                                    Contrasenna = usuario.Contrasenna,
                                                                    Estado = usuario.Estado,
                                                                    Usuario_Creacion = usuario.Usuario_Creacion,
                                                                    Fecha_Creacion = usuario.Fecha_Creacion
                                                                }
                                                            );

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return resultado;
                }
            }
            catch (WebException wex)
            {
                throw wex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
    }
}
