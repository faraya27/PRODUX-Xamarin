using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Toasts;
using PRODUX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

        public ICommand TextoCambiadoCommand { get; set; }

        public ICommand CheckCambiadoCommand { get; set; }

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
            CheckCambiadoCommand = new Command(CheckCambiado);
        }

        private void InicializarClase()
        {
            Usuario = "Carolina";
            Contrasenna = "a";
        }

        public void MostrarMensaje(string mensaje)
        {
            App.Current.MainPage.DisplayAlert("Usuarios", mensaje, "OK");
            //Toasts.MakeText(Forms.Context, mensaje, ToastLength.Short).Show();
        }

        private async void validarCredenciales()
        {
            string resultadoValidacion = string.Empty;

            try
            {
                if (Usuario.Equals(""))
                {
                    MostrarMensaje("Debe ingresar el usuario!");
                    return;
                }

                if (Contrasenna.Equals(""))
                {
                    MostrarMensaje("Debe ingresar la contraseña!");
                    return;
                }

                UsuarioModel objUsuario = new UsuarioModel();
                objUsuario.Usuario = Usuario;
                objUsuario.Contrasenna = Contrasenna;

                //UsuarioModel.InsertarUsuarioRealm(objUsuario);
                
                resultadoValidacion = await UsuarioModel.Autenticar(objUsuario);//"VALIDO";

                if (resultadoValidacion == Usuario)
                {
                    if (RecordarCredenciales)
                    {
                        UsuarioModel.InsertarUsuarioRealm(objUsuario);
                    }

                    PRODUX.ViewModel.Globales.UsuarioActivo = Usuario;

                    NavigationPage navigation = new NavigationPage(new PRODUX.View.Menu.Inicio { Title = "Usuario: " + Usuario });
                    navigation.BarBackgroundColor = Color.Black;
                    navigation.BarTextColor = Color.White;

                    App.Current.MainPage = new MasterDetailPage
                    {
                        Master = new PRODUX.View.Menu.Menu(),
                        Detail = navigation
                    };
                }
                else
                {
                    MostrarMensaje("Usuario y contraseña incorrectas!");
                }

                Usuario = string.Empty;
                Contrasenna = string.Empty;
                RecordarCredenciales = false;
            }
            catch (Exception ex)
            {
                MostrarMensaje("No fue posible verificar las credenciales!");
            }
        }

        private void CheckCambiado()
        {
            if (RecordarCredenciales) RecordarCredenciales = false;
            else RecordarCredenciales = true;
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
