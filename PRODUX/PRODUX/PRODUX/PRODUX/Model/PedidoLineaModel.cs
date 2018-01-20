using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PRODUX.Model
{
    public class PedidoLineaModel : INotifyPropertyChanged
    {
        public PedidoLineaModel() { }

        #region Variables

        private bool _Seleccionado = false;

        private double _Cant_Solicitada = 0;

        #endregion

        #region Propiedades

        public string Id_Pedido { get; set; }

        public string Id_Producto { get; set; }

        public string Desc_Producto { get; set; }

        public string Imagen { get; set; }

        public bool Seleccionado
        {
            get
            {
                return _Seleccionado;
            }
            set
            {
                _Seleccionado = value;
                OnPropertyChanged("Seleccionado");
            }
        }

        public double Cant_Solicitada
        {
            get
            {
                return _Cant_Solicitada;
            }
            set
            {
                _Cant_Solicitada = value;
                OnPropertyChanged("Cant_Solicitada");
            }
        }
                
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
                    var uri = new Uri(URLAPI.PedidoLinea() + "SeleccionarPedidoLinea?codigo=" + pedido);

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
                                                                Desc_Producto = pedidoLinea.Desc_Producto,
                                                                Imagen = pedidoLinea.Imagen,
                                                                Seleccionado = pedidoLinea.Seleccionado,
                                                                Cant_Solicitada = pedidoLinea.Cant_Solicitada,
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

        public static async Task<string> Eliminar(string IdPedido)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.PedidoLinea() + "EliminarPedidoLinea?pedido=" + IdPedido);

                    HttpResponseMessage response = client.GetAsync(uri).Result;
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

        #region Notified Interface

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion
    }
}
