using Plugin.Media;
using PRODUX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PRODUX.ViewModel
{
    public class ProductoViewModel : INotifyPropertyChanged
    {
        #region Singleton

        public static ProductoViewModel instance = null;

        private ProductoViewModel()
        {
            InicializarClase();
            InicializarComandos();
        }

        public static ProductoViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductoViewModel();
            }

            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        #endregion

        #region Variables

        private string _Filtro = string.Empty;

        private string _Codigo = string.Empty;

        private string _Descripcion = string.Empty;

        private double _Precio = 0;

        private int _CantidadInventario = 0;

        private bool _Estado = true;

        private string _Observaciones = string.Empty;

        private string _Imagen = string.Empty;

        private List<ProductoModel> _lstOriginalProductos = new List<ProductoModel>();

        private ObservableCollection<ProductoModel> _lstProductos = new ObservableCollection<ProductoModel>();

        private ProductoModel _ProductoActual = null;

        #endregion

        #region Propiedades

        public ICommand GuardarProductoCommand { get; set; }

        public ICommand EliminarProductoCommand { get; set; }

        public ICommand EditarProductoCommand { get; set; }

        public ICommand TomarFotoCommand { get; set; }

        public ICommand VerImagenCommand { get; set; }

        public string Filtro
        {
            get
            {
                return _Filtro;
            }
            set
            {
                _Filtro = value;
                OnPropertyChanged("Filtro");
                FiltrarLista(_Filtro);
            }
        }

        public string Codigo
        {
            get
            {
                return _Codigo;
            }
            set
            {
                _Codigo = value;
                OnPropertyChanged("Codigo");
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }

        public double Precio
        {
            get
            {
                return _Precio;
            }
            set
            {
                _Precio = value;
                OnPropertyChanged("Precio");
            }
        }

        public int CantidadInventario
        {
            get
            {
                return _CantidadInventario;
            }
            set
            {
                _CantidadInventario = value;
                OnPropertyChanged("CantidadInventario");
            }
        }

        public bool Estado
        {
            get
            {
                return _Estado;
            }
            set
            {
                _Estado = value;
                OnPropertyChanged("Estado");
            }
        }

        public string Observaciones
        {
            get
            {
                return _Observaciones;
            }
            set
            {
                _Observaciones = value;
                OnPropertyChanged("Observaciones");
            }
        }

        public string Imagen
        {
            get
            {
                return _Imagen;
            }
            set
            {
                _Imagen = value;
                OnPropertyChanged("Imagen");
            }
        }

        public ProductoModel ProductoActual
        {
            get
            {
                return _ProductoActual;
            }
            set
            {
                _ProductoActual = value;
                OnPropertyChanged("ProductoActual");
            }
        }

        public ObservableCollection<ProductoModel> LstProductos
        {
            get
            {
                return _lstProductos;
            }
            set
            {
                _lstProductos = value;
                OnPropertyChanged("LstProductos");
            }
        }

        #endregion

        #region Métodos

        private void InicializarComandos()
        {
            GuardarProductoCommand = new Command(GuardarProducto);
            EliminarProductoCommand = new Command(EliminarProducto);
            EditarProductoCommand = new Command<ProductoModel>(EditarProducto);
            TomarFotoCommand = new Command(TomarFoto);
            VerImagenCommand = new Command<ProductoModel>(VerImagen);
        }

        private void InicializarClase()
        {            
            RefrescarLista();
        }

        private async void RefrescarLista()
        {
            LstProductos = await ProductoModel.SeleccionarTodos();
            _lstOriginalProductos = LstProductos.ToList();
        }

        private void Limpiar()
        {
            Codigo = string.Empty;
            Descripcion = string.Empty;
            Precio = 0;
            CantidadInventario = 0;
            Estado = false;
            Observaciones = string.Empty;
            Imagen = string.Empty;
        }

        public void MostrarMensaje(string mensaje)
        {
            App.Current.MainPage.DisplayAlert("Productos", mensaje, "OK");
            //Toasts.MakeText(Forms.Context, mensaje, ToastLength.Short).Show();
        }

        private async void GuardarProducto()
        {
            string resultado = string.Empty;

            try
            {
                if (Codigo.Equals(""))
                {
                    MostrarMensaje("Debe ingresar el código!");
                    return;
                }

                if (Descripcion.Equals(""))
                {
                    MostrarMensaje("Debe ingresar la descripción!");
                    return;
                }

                if (Precio == 0)
                {
                    MostrarMensaje("Debe ingresar el precio!");
                    return;
                }

                ProductoModel objProducto = new ProductoModel();
                objProducto.Codigo = Codigo;
                objProducto.Descripcion = Descripcion;
                objProducto.Precio = Precio;
                objProducto.CantidadInventario = CantidadInventario;
                objProducto.Estado = Convert.ToInt32(Estado);
                objProducto.Observaciones = Observaciones;
                objProducto.Imagen = Imagen;
                objProducto.Usuario_Creacion = "admin"; //FALTA ASIGNAR
                objProducto.Fecha_Creacion = DateTime.Now;

                if(_ProductoActual == null) resultado = await ProductoModel.Insertar(objProducto);
                else resultado = await ProductoModel.Actualizar(objProducto);

                if (resultado.Equals("true"))
                {
                    RefrescarLista();
                    MostrarMensaje("Producto guardado");
                    Limpiar();
                    return;
                }
                else
                {
                    MostrarMensaje("No fue posible guardar el producto, por favor verificar los datos ingresados");
                    return;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("No fue posible insertar el producto!");
            }
        }

        private void EliminarProducto()
        {

        }

        private void EditarProducto(ProductoModel producto)
        {
            _ProductoActual = producto;

            Codigo = producto.Codigo;
            Descripcion = producto.Descripcion;
            Precio = producto.Precio;
            CantidadInventario = producto.CantidadInventario;
            Estado = Convert.ToBoolean(producto.Estado);
            Observaciones = producto.Observaciones;
            Imagen = producto.Imagen;
        }

        private void FiltrarLista(string filtro)
        {
            LstProductos.Clear();
            _lstOriginalProductos.Where(x => x.Descripcion.ToLower().Contains(filtro.ToLower())).ToList().ForEach(x => LstProductos.Add(x));
        }

        private async void TomarFoto()
        {
            try
            {
                string rutaFoto;

                await CrossMedia.Current.Initialize();

                if (CrossMedia.Current.IsTakePhotoSupported)
                {
                    Plugin.Media.Abstractions.StoreCameraMediaOptions opciones = new Plugin.Media.Abstractions.StoreCameraMediaOptions();

                    var foto = await CrossMedia.Current.TakePhotoAsync(opciones);

                    if (foto != null)
                    {
                        rutaFoto = foto.Path;

                        byte[] array = File.ReadAllBytes(rutaFoto);
                        Imagen = Convert.ToBase64String(array);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("No fue posible tomar la foto!");
            }            
        }

        private void VerImagen(ProductoModel producto)
        {
            ProductoActual = producto;
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PRODUX.View.Producto.ImagenProducto());
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
