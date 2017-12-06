using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
