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

        private void InicializarClase()
        {
            RefrescarLista();            
        }

        private async void RefrescarLista()
        {
            LstClientes = await ClienteModel.SeleccionarTodos();
            _lstOriginalClientes = LstClientes.ToList();
        }

        private void Limpiar()
        {
            Cedula = string.Empty;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            Estado = false;
            Direccion = string.Empty;
        }

        public void MostrarMensaje(string mensaje)
        {
            App.Current.MainPage.DisplayAlert("Clientes", mensaje, "OK");
            //Toasts.MakeText(Forms.Context, mensaje, ToastLength.Short).Show();
        }

        private async void GuardarCliente()
        {
            string resultado = string.Empty;

            try
            {
                if (Cedula.Equals(""))
                {
                    MostrarMensaje("Debe ingresar la cédula!");
                    return;
                }

                if (Nombre.Equals(""))
                {
                    MostrarMensaje("Debe ingresar el nombre!");
                    return;
                }

                if (Telefono.Equals(""))
                {
                    MostrarMensaje("Debe ingresar el teléfono!");
                    return;
                }

                if (Email.Equals(""))
                {
                    MostrarMensaje("Debe ingresar el email!");
                    return;
                }

                if (Direccion.Equals(""))
                {
                    MostrarMensaje("Debe ingresar la dirección!");
                    return;
                }

                ClienteModel objCliente = new ClienteModel();
                objCliente.Cedula = Cedula;
                objCliente.Nombre = Nombre;
                objCliente.Telefono = Telefono;
                objCliente.Email = Email;
                objCliente.Estado = Convert.ToInt32(Estado);
                objCliente.Direccion = Direccion;
                objCliente.Usuario_Creacion = "admin"; //FALTA ASIGNAR
                objCliente.Fecha_Creacion = DateTime.Now;

                if(_ClienteActual == null) resultado = await ClienteModel.Insertar(objCliente);
                else resultado = await ClienteModel.Actualizar(objCliente);

                if (resultado.Equals("true"))
                {
                    RefrescarLista();
                    MostrarMensaje("Cliente guardado");
                    Limpiar();
                    return;
                }
                else
                {
                    MostrarMensaje("No fue posible guardar el cliente, por favor verificar los datos ingresados");
                    return;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("No fue posible insertar el cliente!");
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
