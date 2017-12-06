using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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

        #region Métodos

        private void InicializarComandos()
        {


        }

        private void InicializarClase()
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
