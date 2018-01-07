using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PRODUX.Model
{
    public class ClienteModel
    {
        public ClienteModel() { }

        #region Propiedades

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public int Estado { get; set; }

        public string Direccion { get; set; }

        public string Usuario_Creacion { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        #endregion

        #region Métodos

        public static async Task<ObservableCollection<ClienteModel>> SeleccionarTodos()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Cliente() + "SeleccionarClientes");

                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return new ObservableCollection<ClienteModel>(JsonConvert.DeserializeObject<ClienteModel[]>(resultado).ToList());
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

        public static async Task<ClienteModel> SeleccionarPorCodigo(string codigo)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Cliente() + "SeleccionarClientesPorCodigo");

                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ClienteModel>(resultado);
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

        public static async Task<string> Insertar(ClienteModel cliente)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Cliente() + "InsertarCliente");

                    var json = JsonConvert.SerializeObject(
                                                            new {
                                                                    Cedula = cliente.Cedula,
                                                                    Nombre = cliente.Nombre,
                                                                    Telefono = cliente.Telefono,
                                                                    Email = cliente.Email,
                                                                    Estado = cliente.Estado,
                                                                    Direccion = cliente.Direccion,
                                                                    Usuario_Creacion = cliente.Usuario_Creacion,
                                                                    Fecha_Creacion = cliente.Fecha_Creacion
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

        public static async Task<string> Actualizar(ClienteModel cliente)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Cliente() + "ActualizarCliente");

                    var json = JsonConvert.SerializeObject(
                                                            new
                                                            {
                                                                Cedula = cliente.Cedula,
                                                                Nombre = cliente.Nombre,
                                                                Telefono = cliente.Telefono,
                                                                Email = cliente.Email,
                                                                Estado = cliente.Estado,
                                                                Direccion = cliente.Direccion,
                                                                Usuario_Creacion = cliente.Usuario_Creacion,
                                                                Fecha_Creacion = cliente.Fecha_Creacion
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
