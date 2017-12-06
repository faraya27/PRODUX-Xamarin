using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PRODUX.ViewModel
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        #region Singleton

        public static UsuarioViewModel instance = null;

        private UsuarioViewModel()
        {
            InicializarClase();
            InicializarComandos();
        }

        public static UsuarioViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new UsuarioViewModel();
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
