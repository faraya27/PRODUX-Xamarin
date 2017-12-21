using PRODUX.Model;
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
        
        #region Variables

        private string _Usuario = string.Empty;

        private string _Contrasenna = string.Empty;

        private bool _RecordarCredenciales = false;

        #endregion

        #region Propiedades

        public ICommand ValidarCredencialesCommand { get; set; }

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

        public bool RecordarCredenciales
        {
            get
            {
                return _RecordarCredenciales;
            }
            set
            {
                _RecordarCredenciales = value;
                OnPropertyChanged("RecordarCredenciales");
            }
        }

        #endregion

        #region Métodos

        private void InicializarComandos()
        {
            ValidarCredencialesCommand = new Command(validarCredenciales); 

        }

        private void InicializarClase()
        {

        }

        private async void validarCredenciales()
        {
            string resultadoValidacion = string.Empty;

            try
            {
                if (Usuario.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Login", "Debe ingresar el usuario!", "OK");
                    return;
                }

                if (Contrasenna.Equals(""))
                {
                    App.Current.MainPage.DisplayAlert("Login", "Debe ingresar la contraseña!", "OK");
                    return;
                }

                UsuarioModel usuario = new UsuarioModel();
                usuario.Usuario = Usuario;
                usuario.Contrasenna = Contrasenna;

                resultadoValidacion = await UsuarioModel.Autenticar(usuario);

                if (resultadoValidacion == "VALIDO")
                {
                    NavigationPage navigation = new NavigationPage(new PRODUX.View.Menu.Inicio());
                    App.Current.MainPage = new MasterDetailPage
                    {
                        Master = new PRODUX.View.Menu.Menu(),
                        Detail = navigation
                    };
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Login", "Usuario y contraseña incorrectas!", "OK");
                }                
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Login", "No fue posible verificar las credenciales!", "OK");
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
