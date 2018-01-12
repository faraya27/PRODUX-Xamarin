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
using Newtonsoft.Json.Linq;

namespace PRODUX.Model
{
    public class UsuarioModel : RealmObject
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
        
        [Ignored] //El tipo de dato DateTime no es admitido por realm, tiene que ser DateTimeOffset. Se convierte a DateTime asi DateTimeOffset.DateTime
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
                    resultado = JsonConvert.DeserializeObject<string>(resultado);
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
           // string json = "\"[{\\\"Usuario\\\":\\\"Admin\\\",\\\"Contrasenna\\\":\\\"admin\\\",\\\"Estado\\\":1,\\\"Usuario_Creacion\\\":\\\"caro\\\",\\\"Fecha_Creacion\\\":\\\"2018-01-02T20:23:24\\\"},{\\\"Usuario\\\":\\\"c\\\",\\\"Contrasenna\\\":\\\"c\\\",\\\"Estado\\\":1,\\\"Usuario_Creacion\\\":\\\"caro\\\",\\\"Fecha_Creacion\\\":\\\"2017-12-27T20:39:20\\\"},{\\\"Usuario\\\":\\\"Carolina\\\",\\\"Contrasenna\\\":\\\"a\\\",\\\"Estado\\\":1,\\\"Usuario_Creacion\\\":\\\"Admin\\\",\\\"Fecha_Creacion\\\":\\\"2017-12-14T20:31:45\\\"},{\\\"Usuario\\\":\\\"Carolina1\\\",\\\"Contrasenna\\\":\\\"a\\\",\\\"Estado\\\":1,\\\"Usuario_Creacion\\\":\\\"Caro\\\",\\\"Fecha_Creacion\\\":\\\"2017-12-27T20:40:53\\\"},{\\\"Usuario\\\":\\\"Carolina1k\\\",\\\"Contrasenna\\\":\\\"a\\\",\\\"Estado\\\":1,\\\"Usuario_Creacion\\\":\\\"Caro\\\",\\\"Fecha_Creacion\\\":\\\"2017-12-27T20:48:45\\\"}]\"";

            //UsuarioModel[] jsonObject = JsonConvert.DeserializeObject<UsuarioModel[]>(json);

            //ObservableCollection<UsuarioModel> LstUsuarios = new ObservableCollection<UsuarioModel>(jsonObject.ToList());
            //return;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Usuario() + "SeleccionarUsuarios"); 
                    
                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    string resultado = await response.Content.ReadAsStringAsync();
                    return new ObservableCollection<UsuarioModel>(JsonConvert.DeserializeObject<UsuarioModel[]>(resultado).ToList());
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

        public static async Task<UsuarioModel> SeleccionarPorCodigo(string codigo)
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
                    var uri = new Uri(URLAPI.Usuario() + "ActualizarUsuario");

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
            catch (WebException ex)
            {

                throw;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //Metodos REALM
        public static void InsertarUsuarioRealm(UsuarioModel usuario)
        {
            var realm = Realm.GetInstance();

            realm.Write(() =>
            {
                var usuarioRealm = new UsuarioModel
                {
                    Usuario = usuario.Usuario,
                    Contrasenna = usuario.Contrasenna
                };

                realm.Add(usuarioRealm);
            });            
        }

        public static void EliminarUsuarioRealm()
        {
            var realm = Realm.GetInstance();

            List<UsuarioModel> lstUsuarios = realm.All<UsuarioModel>().ToList();

            using (var trans = realm.BeginWrite())
            {
                foreach (UsuarioModel usuario in lstUsuarios)
                {
                    realm.Remove(usuario);
                }

                trans.Commit();
            }                
        }

        public static UsuarioModel ObtenerUsuarioRealm()
        {
            var realm = Realm.GetInstance();

            return realm.All<UsuarioModel>().First();
        }

        #endregion
        
    }
}
