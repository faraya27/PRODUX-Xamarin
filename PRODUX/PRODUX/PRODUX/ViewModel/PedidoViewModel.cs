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
    public class PedidoViewModel : INotifyPropertyChanged
    {
        #region Singleton

        public static PedidoViewModel instance = null;

        private PedidoViewModel()
        {
            InicializarComandos();
        }

        public static PedidoViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new PedidoViewModel();
            }

            instance.InicializarClase();

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

        private List<PedidoModel> _lstOriginalPedidos = new List<PedidoModel>();

        private ObservableCollection<PedidoModel> _lstPedidos = new ObservableCollection<PedidoModel>();

        private ObservableCollection<PedidoLineaModel> _lstPedidoLinea = new ObservableCollection<PedidoLineaModel>();

        private ObservableCollection<ClienteModel> _lstClientes = new ObservableCollection<ClienteModel>();

        private ObservableCollection<ProductoModel> _lstProductos = new ObservableCollection<ProductoModel>();

        private PedidoModel _PedidoActual = null;

        #endregion

        #region Propiedades

        public ICommand GuardarPedidoCommand { get; set; }

        public ICommand EliminarPedidoCommand { get; set; }

        public ICommand ConfirmarPedidoCommand { get; set; }

        public ICommand EditarPedidoCommand { get; set; }

        public ICommand CantidadCambiadaCommand { get; set; }

        public ICommand CheckCambiadoCommand { get; set; }

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

        public ObservableCollection<PedidoLineaModel> LstPedidoLinea
        {
            get
            {
                return _lstPedidoLinea;
            }
            set
            {
                _lstPedidoLinea = value;
                OnPropertyChanged("LstPedidoLinea");
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
            CheckCambiadoCommand = new Command<PedidoLineaModel>(CheckCambiado);
            CantidadCambiadaCommand = new Command<PedidoLineaModel>(CantidadCambiada);
        }

        private void InicializarClase()
        {
            RefrescarLista();
            Limpiar();
        }

        public void MostrarMensaje(string mensaje)
        {
            App.Current.MainPage.DisplayAlert("Pedidos", mensaje, "OK");
            //Toasts.MakeText(Forms.Context, mensaje, ToastLength.Short).Show();
        }

        private async void GuardarPedido()
        {
            string resultado = string.Empty;

            try
            {
                if (IdPedido.Equals(""))
                {
                    MostrarMensaje("Debe ingresar la Numero del Pedido!");
                    return;
                }
                if (Fecha.Equals(""))
                {
                    MostrarMensaje("Debe ingresar La Fecha!");
                    return;
                }
                if (Cliente == null)
                {
                    MostrarMensaje("Debe ingresar el Cliente!");
                    return;
                }

                int cantidadDetalles = LstPedidoLinea.Where(x => x.Seleccionado == true).Count();

                if (cantidadDetalles == 0)
                {
                    MostrarMensaje("Debe seleccionar productos para poder guardar el pedido!");
                    return;
                }
                
                PedidoModel pedido = new PedidoModel();
                pedido.Id_Pedido = IdPedido;
                pedido.Fecha = Fecha;
                pedido.Cliente = Cliente.Cedula;
                pedido.Estado = 1;
                pedido.TotalPedido = TotalPedido;
                pedido.Usuario_Creacion = Globales.UsuarioActivo;
                pedido.Usuario_Confirmacion = string.Empty;

                if (_PedidoActual == null)
                {
                    resultado = await PedidoModel.Insertar(pedido);
                }
                else
                {
                    resultado = await PedidoModel.Actualizar(pedido);

                    resultado = await PedidoLineaModel.Eliminar(IdPedido);
                }
                
                foreach (PedidoLineaModel pedidoLinea in LstPedidoLinea)
                {
                    if (pedidoLinea.Seleccionado)
                    {
                        pedidoLinea.Id_Pedido = IdPedido;
                        resultado = await PedidoLineaModel.Insertar(pedidoLinea);
                    }
                }

                if (resultado.Equals("true"))
                {                    
                    MostrarMensaje("Pedido guardado");
                    Limpiar();
                    RefrescarLista();
                    return;
                }
                else
                {
                    MostrarMensaje("No fue posible guardar el pedido, por favor verificar los datos ingresados");
                    return;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("No fue posible guardar el pedido, por favor verificar los datos ingresados");
            }
        }

        private void Limpiar()
        {
            IdPedido = string.Empty;
            Fecha = DateTime.Now;
            Cliente = null;
            TotalPedido = 0;            
        }

        private async void RefrescarLista()
        {
            LstPedidos = await PedidoModel.SeleccionarTodos();
            _lstOriginalPedidos = LstPedidos.ToList();

            LstClientes = await ClienteModel.SeleccionarActivos();
            LstPedidoLinea = await PedidoLineaModel.SeleccionarPorPedido(IdPedido);
        }

        private async void EliminarPedido()
        {
            string resultado = string.Empty;

            try
            {
                resultado = await PedidoLineaModel.Eliminar(_PedidoActual.Id_Pedido);
                resultado = await PedidoModel.Eliminar(_PedidoActual.Id_Pedido);

                MostrarMensaje("Pedido eliminado");
                Limpiar();
                RefrescarLista();
            }
            catch (Exception ex)
            {
                MostrarMensaje("No fue posible eliminar el pedido");
            }            
        }

        private async void ConfirmarPedido()
        {
            string resultado = string.Empty;

            try
            {
                _PedidoActual.Usuario_Confirmacion = Globales.UsuarioActivo;

                resultado = await PedidoModel.Confirmar(_PedidoActual);

                MostrarMensaje("Pedido confirmado");
                Limpiar();
                RefrescarLista();
            }
            catch (Exception ex)
            {
                MostrarMensaje("No fue posible confirmar el pedido");
            }            
        }

        private async void EditarPedido(PedidoModel pedido)
        {
            _PedidoActual = pedido;

            IdPedido = pedido.Id_Pedido;
            Fecha = pedido.Fecha;
            ClienteModel cliente = await ClienteModel.SeleccionarPorCodigo(pedido.Cliente);
            Cliente = cliente;
            TotalPedido = pedido.TotalPedido;

            LstPedidoLinea = await PedidoLineaModel.SeleccionarPorPedido(pedido.Id_Pedido);

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PRODUX.View.Pedido.Pedido());
        }

        private void CheckCambiado(PedidoLineaModel pedidoLinea)
        {
            if (!pedidoLinea.Seleccionado)
            {
                if (pedidoLinea.Cant_Solicitada > 0)
                {
                    pedidoLinea.Seleccionado = true;
                }
                else
                {
                    MostrarMensaje("La cantidad debe de ser mayor a cero");
                }
                
            }                
            else pedidoLinea.Seleccionado = false;

            CalcularTotal();
        }

        private void CantidadCambiada(PedidoLineaModel pedidoLinea)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            try
            {
                TotalPedido = 0;

                foreach (PedidoLineaModel pedidoLinea in LstPedidoLinea)
                {
                    if (pedidoLinea.Seleccionado && pedidoLinea.Cant_Solicitada != 0)
                    {
                        pedidoLinea.Subtotal = pedidoLinea.Cant_Solicitada * pedidoLinea.Precio_Unitario;
                        TotalPedido += pedidoLinea.Subtotal;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("No fue posible calcular los totales");
            }            
        }

        private void FiltrarLista(string filtro)
        {
            LstPedidos.Clear();
            _lstOriginalPedidos.Where(x => x.Id_Pedido.ToLower().Contains(filtro.ToLower())).ToList().ForEach(x => LstPedidos.Add(x));
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
