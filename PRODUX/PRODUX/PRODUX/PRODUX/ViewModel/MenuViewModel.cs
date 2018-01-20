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
            TabbedPage ProductoTab = new PRODUX.View.Producto.ProductoTab();
            ProductoTab.Children.Add( new PRODUX.View.Producto.ConsultaProducto());
            ProductoTab.Children.Add(new PRODUX.View.Producto.Producto());
            ProductoTab.Title = "Productos";
            ProductoTab.BarBackgroundColor = Color.Black;
            ProductoTab.BarTextColor = Color.White;

            ((MasterDetailPage)App.Current.MainPage).IsPresented = false;
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopToRootAsync();
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(ProductoTab);            
        }

        private void AbrirPantallaPedido()
        {
            ((MasterDetailPage)App.Current.MainPage).IsPresented = false;
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopToRootAsync();
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PRODUX.View.Pedido.Pedido { Title = "Pedidos" });            
        }

        private void AbrirPantallaConsultaPedidos()
        {
            ((MasterDetailPage)App.Current.MainPage).IsPresented = false;
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopToRootAsync();
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PRODUX.View.Pedido.ConsultaPedido { Title = "Pedidos" });            
        }

        private void AbrirPantallaCliente()
        {
            TabbedPage ClienteTab = new PRODUX.View.Cliente.ClienteTab();
            ClienteTab.Children.Add(new PRODUX.View.Cliente.ConsultaCliente());
            ClienteTab.Children.Add(new PRODUX.View.Cliente.Cliente());
            ClienteTab.Title = "Clientes";
            ClienteTab.BarBackgroundColor = Color.Black;
            ClienteTab.BarTextColor = Color.White;

            ((MasterDetailPage)App.Current.MainPage).IsPresented = false;
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopToRootAsync();
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(ClienteTab);            
        }

        private void AbrirPantallaUsuario()
        {
            TabbedPage UsuarioTab = new PRODUX.View.Usuario.UsuarioTab();
            UsuarioTab.Children.Add(new PRODUX.View.Usuario.ConsultaUsuario());
            UsuarioTab.Children.Add(new PRODUX.View.Usuario.Usuario());
            UsuarioTab.Title = "Usuarios";
            UsuarioTab.BarBackgroundColor = Color.Black;
            UsuarioTab.BarTextColor = Color.White;

            ((MasterDetailPage)App.Current.MainPage).IsPresented = false;
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopToRootAsync();
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(UsuarioTab);            
        }

        private void CerrarSesion()
        {
            PRODUX.Model.UsuarioModel.EliminarUsuarioRealm();
            ProductoViewModel.DeleteInstance();
            ClienteViewModel.DeleteInstance();
            UsuarioViewModel.DeleteInstance();
            PedidoViewModel.DeleteInstance();

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
