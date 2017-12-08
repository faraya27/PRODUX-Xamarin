using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PRODUX.ViewModel
{
    public class InicioSesionViewModel : INotifyPropertyChanged
    {
        #region Singleton

        public static InicioSesionViewModel instance = null;

        private InicioSesionViewModel()
        {
            InicializarClase();
            InicializarComandos();
        }

        public static InicioSesionViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new InicioSesionViewModel();
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

        public ICommand ValidarCredencialesCommand { get; set; }

        #endregion

        #region Métodos

        private void InicializarComandos()
        {
            ValidarCredencialesCommand = new Command(validarCredenciales); 

        }

        private void InicializarClase()
        {

        }

        private void validarCredenciales()
        {
            NavigationPage navigation = new NavigationPage(new PRODUX.View.Menu.Inicio());
            App.Current.MainPage = new MasterDetailPage
            {
                Master = new PRODUX.View.Menu.Menu(),
                Detail = navigation
            };
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
