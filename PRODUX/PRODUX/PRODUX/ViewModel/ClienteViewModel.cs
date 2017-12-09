using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PRODUX.ViewModel
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        #region Singleton

        public static ClienteViewModel instance = null;

        private ClienteViewModel()
        {
            InicializarClase();
            InicializarComandos();
        }

        public static ClienteViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new ClienteViewModel();
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

        private string _Cedula = string.Empty;

        private string _Nombre = string.Empty;

        private string _Telefono = string.Empty;

        private string _Email = string.Empty;

        private bool _Estado = true;

        private string _Direccion = string.Empty;

        #endregion

        #region Propiedades

        public ICommand GuardarClienteCommand { get; set; }

        public string Cedula
        {
            get
            {
                return _Cedula;
            }
            set
            {
                _Cedula = value;
                OnPropertyChanged("Cedula");
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        public string Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                _Telefono = value;
                OnPropertyChanged("Telefono");
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged("Email");
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

        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                _Direccion = value;
                OnPropertyChanged("Direccion");
            }
        }

        #endregion

        #region Métodos

        private void InicializarComandos()
        {
            GuardarClienteCommand = new Command(GuardarCliente);
        }

        private void InicializarClase()
        {
            
        }

        private void GuardarCliente()
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
