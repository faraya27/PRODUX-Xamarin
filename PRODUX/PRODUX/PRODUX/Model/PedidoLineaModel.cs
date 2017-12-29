using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PRODUX.Model
{
    public class PedidoLineaModel
    {
        public PedidoLineaModel() { }

        #region Propiedades

        public string Id_Pedido { get; set; }

        public string Id_Producto { get; set; }

        public double Cant_Solicitada { get; set; }

        public double Precio_Unitario { get; set; }

        public double Subtotal { get; set; }

        #endregion

        #region Métodos

        public static async Task<ObservableCollection<PedidoLineaModel>> SeleccionarPorPedido(string pedido)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.PedidoLinea() + "SeleccionarPedidoLinea");

                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ObservableCollection<PedidoLineaModel>>(resultado);
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

        public static async Task<string> Insertar(PedidoLineaModel pedidoLinea)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.PedidoLinea() + "InsertarPedidoLinea");

                    var json = JsonConvert.SerializeObject(
                                                            new
                                                            {
                                                                Id_Pedido = pedidoLinea.Id_Pedido,
                                                                Id_Producto = pedidoLinea.Id_Producto,
                                                                Cantidad_Solicitada = pedidoLinea.Cant_Solicitada,
                                                                Precio_Unitario = pedidoLinea.Precio_Unitario,
                                                                Subtotal = pedidoLinea.Subtotal
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

        public static async Task<string> Actualizar(PedidoLineaModel pedidoLinea)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.PedidoLinea() + "ActualizarPedidoLinea");

                    var json = JsonConvert.SerializeObject(
                                                            new
                                                            {
                                                                Id_Pedido = pedidoLinea.Id_Pedido,
                                                                Id_Producto = pedidoLinea.Id_Producto,
                                                                Cantidad_Solicitada = pedidoLinea.Cant_Solicitada,
                                                                Precio_Unitario = pedidoLinea.Precio_Unitario,
                                                                Subtotal = pedidoLinea.Subtotal
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

        public static async Task<string> Eliminar(PedidoLineaModel pedidoLinea)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.PedidoLinea() + "EliminarPedidoLinea");

                    var json = JsonConvert.SerializeObject(
                                                            new
                                                            {
                                                                Id_Pedido = pedidoLinea.Id_Pedido,
                                                                Id_Producto = pedidoLinea.Id_Producto,
                                                                Cantidad_Solicitada = pedidoLinea.Cant_Solicitada,
                                                                Precio_Unitario = pedidoLinea.Precio_Unitario,
                                                                Subtotal = pedidoLinea.Subtotal
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
