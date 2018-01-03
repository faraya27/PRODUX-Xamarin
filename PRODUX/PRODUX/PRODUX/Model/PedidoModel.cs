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
    public class PedidoModel
    {
        public PedidoModel() { }

        #region Propiedades

        public string Id_Pedido { get; set; }

        public DateTime Fecha { get; set; }

        public string Cliente { get; set; }

        public string Estado { get; set; }

        public double TotalPedido { get; set; }

        public string Usuario_Confirmacion { get; set; }

        public string Usuario_Creacion { get; set; }

        #endregion

        #region Métodos

        public static async Task<ObservableCollection<PedidoModel>> SeleccionarTodos()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Pedido() + "SeleccionarPedidos");

                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return new ObservableCollection<PedidoModel>(JsonConvert.DeserializeObject<PedidoModel[]>(resultado).ToList());
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

        public static async Task<PedidoModel> SeleccionarPorCodigo(string codigo)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Pedido() + "SeleccionarPedidosPorCodigo");

                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<PedidoModel>(resultado);
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

        public static async Task<string> Insertar(PedidoModel pedido)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Pedido() + "InsertarPedido");

                    var json = JsonConvert.SerializeObject(
                                                            new
                                                            {
                                                                Id_Pedido = pedido.Id_Pedido,
                                                                Fecha = pedido.Fecha,
                                                                Cliente = pedido.Cliente,
                                                                ToTalPedido = pedido.TotalPedido,
                                                                Estado = pedido.Estado,
                                                                Usuario_Creacion = pedido.Usuario_Creacion
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

        public static async Task<string> Actualizar(PedidoModel pedido)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Pedido() + "ActualizarPedido");

                    var json = JsonConvert.SerializeObject(
                                                            new
                                                            {
                                                                Id_Pedido = pedido.Id_Pedido,
                                                                Fecha = pedido.Fecha,
                                                                Cliente = pedido.Cliente,
                                                                ToTalPedido = pedido.TotalPedido,
                                                                Estado = pedido.Estado,
                                                                Usuario_Confirmacion = pedido.Usuario_Confirmacion
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

        public static async Task<string> Eliminar(PedidoModel pedido)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Pedido() + "EliminarPedido");

                    var json = JsonConvert.SerializeObject(
                                                            new
                                                            {
                                                                Id_Pedido = pedido.Id_Pedido,
                                                                Fecha = pedido.Fecha,
                                                                Cliente = pedido.Cliente,
                                                                ToTalPedido = pedido.TotalPedido,
                                                                Estado = pedido.Estado,
                                                                Usuario_Confirmacion = pedido.Usuario_Confirmacion
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
