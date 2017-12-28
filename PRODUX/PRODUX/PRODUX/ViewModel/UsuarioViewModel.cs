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

        #region Variables

        private string _Filtro = string.Empty;

        private string _Usuario = string.Empty;

        private string _Contrasenna = string.Empty;

        private bool _Estado = true;

        private ObservableCollection<UsuarioModel> _lstUsuarios = new ObservableCollection<UsuarioModel>();

        #endregion

        #region Propiedades

        public ICommand GuardarUsuarioCommand { get; set; }

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

        public string Usuario
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

        public string Contrasenna
        {
            get
            {
                return _Contrasenna;
            }
            set
            {
                _Contrasenna = value;
                OnPropertyChanged("Contrasenna");
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

        public ObservableCollection<UsuarioModel> LstUsuarios
        {
            get
            {
                return _lstUsuarios;
            }
            set
            {
                _lstUsuarios = value;
                OnPropertyChanged("LstUsuarios");
            }
        }

        #endregion

        #region Métodos

        private void InicializarComandos()
        {
            GuardarUsuarioCommand = new Command(GuardarUsuario);
        }

        private void InicializarClase()
        {
            //LstUsuarios = ;
        }

        private async void GuardarUsuario()
        {
            try
            {
                if (Usuario.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Usuarios", "Debe ingresar el usuario!", "OK");
                    return;
                }

                if (Contrasenna.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Usuarios", "Debe ingresar la contraseña!", "OK");
                    return;
                }

                UsuarioModel objUsuario = new UsuarioModel();
                objUsuario.Usuario = Usuario;
                objUsuario.Contrasenna = Contrasenna;
                objUsuario.Estado = Convert.ToInt32(Estado);
                objUsuario.Usuario_Creacion = "admin"; //FALTA ASIGNAR
                objUsuario.Fecha_Creacion = DateTime.Now;

                //Llamar al método de insertar
                await UsuarioModel.Insertar(objUsuario);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Usuarios", "No fue posible insertar el usuario!", "OK");
            }
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
