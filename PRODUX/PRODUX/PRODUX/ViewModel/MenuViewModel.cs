using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PRODUX.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        #region Singleton

        public static MenuViewModel instance = null;

        private MenuViewModel()
        {
            InicializarClase();
            InicializarComandos();
        }

        public static MenuViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MenuViewModel();
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

        #region Instances

        public ICommand AbrirProductoCommand { get; set; }
        public ICommand AbrirPedidoCommand { get; set; }
        public ICommand AbrirConsultaPedidosCommand { get; set; }
        public ICommand AbrirClienteCommand { get; set; }
        public ICommand AbrirUsuarioCommand { get; set; }
        public ICommand CerrarSesionCommand { get; set; }

        #endregion

        #region Métodos

        private void InicializarComandos()
        {
            AbrirProductoCommand = new Command(AbrirPantallaProducto);
            AbrirPedidoCommand = new Command(AbrirPantallaPedido);
            AbrirConsultaPedidosCommand = new Command(AbrirPantallaConsultaPedidos);
            AbrirClienteCommand = new Command(AbrirPantallaCliente);
            AbrirUsuarioCommand = new Command(AbrirPantallaUsuario);
            CerrarSesionCommand = new Command(CerrarSesion);
        }

        private void InicializarClase()
        {

        }

        private void AbrirPantallaProducto()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PRODUX.View.Producto.ProductoTab());
        }

        private void AbrirPantallaPedido()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PRODUX.View.Pedido.Pedido());
        }

        private void AbrirPantallaConsultaPedidos()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PRODUX.View.Pedido.ConsultaPedido());
        }

        private void AbrirPantallaCliente()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PRODUX.View.Cliente.ClienteTab());
        }

        private void AbrirPantallaUsuario()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PRODUX.View.Usuario.UsuarioTab());
        }

        private void CerrarSesion()
        {
            Application.Current.MainPage = new PRODUX.View.InicioSesion();
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
