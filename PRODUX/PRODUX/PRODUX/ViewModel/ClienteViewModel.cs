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

        private List<ClienteModel> _lstOriginalClientes = new List<ClienteModel>();

        private ObservableCollection<ClienteModel> _lstClientes = new ObservableCollection<ClienteModel>();

        private ClienteModel _ClienteActual = null;

        #endregion

        #region Propiedades

        public ICommand GuardarClienteCommand { get; set; }

        public ICommand EditarClienteCommand { get; set; }

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
            EditarClienteCommand = new Command<ClienteModel>(EditarCliente);
        }

        private async void InicializarClase()
        {
            LstClientes = await ClienteModel.SeleccionarTodos();
            _lstOriginalClientes = LstClientes.ToList();
        }

        private async void GuardarCliente()
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

                if(_ClienteActual == null) await ClienteModel.Insertar(objCliente);
                else await ClienteModel.Actualizar(objCliente);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Clientes", "No fue posible insertar el cliente!", "OK");
            }
        }

        private void EditarCliente(ClienteModel cliente)
        {
            _ClienteActual = cliente;

            Cedula = cliente.Cedula;
            Nombre = cliente.Nombre;
            Telefono = cliente.Telefono;
            Email = cliente.Email;
            Estado = Convert.ToBoolean(cliente.Estado);
            Direccion = cliente.Direccion;
        }

        private void FiltrarLista(string filtro)
        {
            LstClientes.Clear();
            _lstOriginalClientes.Where(x => x.Nombre.ToLower().Contains(filtro.ToLower())).ToList().ForEach(x => LstClientes.Add(x));
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
