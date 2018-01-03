using PRODUX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        private double _CantidadInventario = 0;

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

        public double CantidadInventario
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
        }

        private async void InicializarClase()
        {
            LstProductos = await ProductoModel.SeleccionarTodos();
            _lstOriginalProductos = LstProductos.ToList();
        }

        private async void GuardarProducto()
        {
            try
            {
                if (Codigo.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Productos", "Debe ingresar el código!", "OK");
                    return;
                }

                if (Descripcion.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Productos", "Debe ingresar la descripción!", "OK");
                    return;
                }

                if (Precio == 0)
                {
                    App.Current.MainPage.DisplayAlert("Productos", "Debe ingresar el precio!", "OK");
                    return;
                }

                if (Imagen.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Productos", "Debe seleccionar una imagen!", "OK");
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
                objProducto.Usuario_Creacion = ""; //FALTA ASIGNAR
                objProducto.Fecha_Creacion = DateTime.Now;

                if(_ProductoActual == null) await ProductoModel.Insertar(objProducto);
                else await ProductoModel.Actualizar(objProducto);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Productos", "No fue posible insertar el producto!", "OK");
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
