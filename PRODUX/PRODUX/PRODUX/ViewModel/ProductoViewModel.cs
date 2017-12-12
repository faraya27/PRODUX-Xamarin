using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        #endregion

        #region Propiedades

        public ICommand GuardarProductoCommand { get; set; }

        public ICommand EliminarProductoCommand { get; set; }

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

        #endregion

        #region Métodos

        private void InicializarComandos()
        {
            GuardarProductoCommand = new Command(GuardarProducto);
            EliminarProductoCommand = new Command(EliminarProducto);
        }

        private void InicializarClase()
        {

        }

        private void GuardarProducto()
        {

        }

        private void EliminarProducto()
        {

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
