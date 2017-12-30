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
    public class PedidoViewModel : INotifyPropertyChanged
    {
        #region Singleton

        public static PedidoViewModel instance = null;

        private PedidoViewModel()
        {
            InicializarClase();
            InicializarComandos();
        }

        public static PedidoViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new PedidoViewModel();
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

        private string _IdPedido = string.Empty;

        private DateTime _Fecha = DateTime.Now;

        private ClienteModel _Cliente = new ClienteModel();

        private UsuarioModel _Usuario = new UsuarioModel();

        private double _TotalPedido = 0;

        private ObservableCollection<PedidoModel> _lstPedidos = new ObservableCollection<PedidoModel>();

        private ObservableCollection<ProductoModel> _lstProductos = new ObservableCollection<ProductoModel>();

        #endregion

        #region Propiedades

        public ICommand GuardarPedidoCommand { get; set; }

        public ICommand EliminarPedidoCommand { get; set; }

        public ICommand ConfirmarPedidoCommand { get; set; }

        public ICommand EditarPedidoCommand { get; set; }

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

        public string IdPedido
        {
            get
            {
                return _IdPedido;
            }
            set
            {
                _IdPedido = value;
                OnPropertyChanged("IdPedido");
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                _Fecha = value;
                OnPropertyChanged("Fecha");
            }
        }

        public ClienteModel Cliente
        {
            get
            {
                return _Cliente;
            }
            set
            {
                _Cliente = value;
                OnPropertyChanged("Cliente");
            }
        }

        public UsuarioModel Usuario
        {
            get
            {
                return _Usuario;
            }
            set
            {
                _Usuario = value;
                OnPropertyChanged("Usuario");
            }
        }

        public double TotalPedido
        {
            get
            {
                return _TotalPedido;
            }
            set
            {
                _TotalPedido = value;
                OnPropertyChanged("TotalPedido");
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

        public ObservableCollection<PedidoModel> LstPedidos
        {
            get
            {
                return _lstPedidos;
            }
            set
            {
                _lstPedidos = value;
                OnPropertyChanged("LstPedidos");
            }
        }

        #endregion

        #region Métodos

        private void InicializarComandos()
        {
            GuardarPedidoCommand = new Command(GuardarPedido);
            EliminarPedidoCommand = new Command(EliminarPedido);
            ConfirmarPedidoCommand = new Command(ConfirmarPedido);
            EditarPedidoCommand = new Command<PedidoModel>(EditarPedido);
        }

        private async void InicializarClase()
        {
            LstPedidos = await PedidoModel.SeleccionarTodos();
        }

        private void GuardarPedido()
        {
            
        }

        private void EliminarPedido()
        {

        }

        private void ConfirmarPedido()
        {

        }

        private void EditarPedido(PedidoModel pedido)
        {
            IdPedido = pedido.Id_Pedido;
            Fecha = pedido.Fecha;
            //Cliente = pedido.Cliente;
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
