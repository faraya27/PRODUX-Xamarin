using PRODUX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private string _Filtro = string.Empty;

        private string _Cedula = string.Empty;

        private string _Nombre = string.Empty;

        private string _Telefono = string.Empty;

        private string _Email = string.Empty;

        private bool _Estado = true;

        private string _Direccion = string.Empty;

        private ObservableCollection<ClienteModel> _lstClientes = new ObservableCollection<ClienteModel>();

        #endregion

        #region Propiedades

        public ICommand GuardarClienteCommand { get; set; }

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

        public ObservableCollection<ClienteModel> LstClientes
        {
            get
            {
                return _lstClientes;
            }
            set
            {
                _lstClientes = value;
                OnPropertyChanged("LstClientes");
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
            //LstClientes = ;
        }

        private void GuardarCliente()
        {
            try
            {
                if (Cedula.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Usuarios", "Debe ingresar la cédula!", "OK");
                    return;
                }

                if (Nombre.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Usuarios", "Debe ingresar el nombre!", "OK");
                    return;
                }

                if (Telefono.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Usuarios", "Debe ingresar el teléfono!", "OK");
                    return;
                }

                if (Email.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Usuarios", "Debe ingresar el email!", "OK");
                    return;
                }

                if (Direccion.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Usuarios", "Debe ingresar la dirección!", "OK");
                    return;
                }

                ClienteModel objCliente = new ClienteModel();
                objCliente.Cedula = Cedula;
                objCliente.Nombre = Nombre;
                objCliente.Telefono = Telefono;
                objCliente.Estado = Convert.ToInt32(Estado);
                objCliente.Direccion = Direccion;
                objCliente.Usuario_Creacion = ""; //FALTA ASIGNAR
                objCliente.Fecha_Creacion = DateTime.Now;

                //Llamar al método de insertar
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Clientes", "No fue posible insertar el cliente!", "OK");
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
