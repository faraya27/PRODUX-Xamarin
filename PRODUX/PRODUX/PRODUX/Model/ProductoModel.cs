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
    public class ProductoModel
    {
        public ProductoModel() { }

        #region Propiedades

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public double CantidadInventario { get; set; }

        public int Estado { get; set; }

        public string Observaciones { get; set; }

        public string Imagen { get; set; }

        public string Usuario_Creacion { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        #endregion

        #region Métodos

        public static async Task<ObservableCollection<ProductoModel>> SeleccionarTodos()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Producto() + "SeleccionarProductos");

                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ObservableCollection<ProductoModel>>(resultado);
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

        public static async Task<ProductoModel> SeleccionarPorCodigo(string codigo)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Producto() + "SeleccionarProductosPorCodigo");

                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    string resultado = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ProductoModel>(resultado);
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

        public static async Task<string> Insertar(ProductoModel producto)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Producto() + "InsertarProducto");

                    var json = JsonConvert.SerializeObject(
                                                            new {
                                                                    Codigo = producto.Codigo,
                                                                    Descripcion = producto.Descripcion,
                                                                    Precio = producto.Precio,
                                                                    CantidadInventario = producto.CantidadInventario,
                                                                    Estado = producto.Estado,
                                                                    Observaciones = producto.Observaciones,
                                                                    Imagen = producto.Imagen,
                                                                    Usuario_Creacion = producto.Usuario_Creacion,
                                                                    Fecha_Creacion = producto.Fecha_Creacion
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

        public static async Task<string> Actualizar(ProductoModel producto)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(URLAPI.Producto() + "ActualizarProducto");

                    var json = JsonConvert.SerializeObject(
                                                            new {
                                                                    Codigo = producto.Codigo,
                                                                    Descripcion = producto.Descripcion,
                                                                    Precio = producto.Precio,
                                                                    CantidadInventario = producto.CantidadInventario,
                                                                    Estado = producto.Estado,
                                                                    Observaciones = producto.Observaciones,
                                                                    Imagen = producto.Imagen,
                                                                    Usuario_Creacion = producto.Usuario_Creacion,
                                                                    Fecha_Creacion = producto.Fecha_Creacion
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
