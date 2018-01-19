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
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        #region Singleton

        public static UsuarioViewModel instance = null;

        private UsuarioViewModel()
        {
            InicializarComandos();
        }

        public static UsuarioViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new UsuarioViewModel();
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

        private string _Usuario = string.Empty;

        private string _Contrasenna = string.Empty;

        private bool _Estado = true;

        private List<UsuarioModel> _lstOriginalUsuarios = new List<UsuarioModel>();

        private ObservableCollection<UsuarioModel> _lstUsuarios = new ObservableCollection<UsuarioModel>();

        private UsuarioModel _UsuarioActual = null;

        #endregion

        #region Propiedades

        public ICommand GuardarUsuarioCommand { get; set; }

        public ICommand EditarUsuarioCommand { get; set; }

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
            EditarUsuarioCommand = new Command<UsuarioModel>(EditarUsuario);
            CheckCambiadoCommand = new Command(CheckCambiado);
        }

        private void InicializarClase()
        {
            RefrescarLista();
            Limpiar();
        }
        
        private async void RefrescarLista()
        {
            LstUsuarios = await UsuarioModel.SeleccionarTodos();
            _lstOriginalUsuarios = LstUsuarios.ToList();
        }

        private void Limpiar()
        {
            Usuario = string.Empty;
            Contrasenna = string.Empty;
            Estado = false;
        }

        public void MostrarMensaje(string mensaje)
        {
            App.Current.MainPage.DisplayAlert("Usuarios", mensaje, "OK");
            //Toasts.MakeText(Forms.Context, mensaje, ToastLength.Short).Show();
        }

        private async void GuardarUsuario()
        {
            string resultado = string.Empty;

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
                objUsuario.Estado = Convert.ToInt32(Estado);
                objUsuario.Usuario_Creacion = Globales.UsuarioActivo;
                objUsuario.Fecha_Creacion = DateTime.Now;
                
                if (_UsuarioActual == null) resultado = await UsuarioModel.Insertar(objUsuario);
                else resultado = await UsuarioModel.Actualizar(objUsuario);

                if (resultado.Equals("true"))
                {
                    RefrescarLista();
                    MostrarMensaje("Usuario guardado");
                    Limpiar();
                    return;
                }
                else
                {
                    MostrarMensaje("No fue posible guardar el usuario, por favor verificar los datos ingresados");
                    return;
                }              
            }
            catch (Exception ex)
            {
                MostrarMensaje("No fue posible insertar el usuario!");
            }
        }
        
        private void EditarUsuario(UsuarioModel usuario)
        {
            _UsuarioActual = usuario;

            Usuario = usuario.Usuario;
            Contrasenna = usuario.Contrasenna;
            Estado = Convert.ToBoolean(usuario.Estado);
                        
            //((TabbedPage)App.Current.MainPage).CurrentPage = ((TabbedPage)App.Current.MainPage).Children[1];
            //((TabbedPage)App.Current.MainPage).CurrentPage.Focus();
        }

        private void FiltrarLista(string filtro)
        {
            LstUsuarios.Clear();
            _lstOriginalUsuarios.Where(x => x.Usuario.ToLower().Contains(filtro.ToLower())).ToList().ForEach(x => LstUsuarios.Add(x));
        }

        private void CheckCambiado()
        {
            if (Estado) Estado = false;
            else Estado = true;
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
