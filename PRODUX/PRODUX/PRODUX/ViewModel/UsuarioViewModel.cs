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

        private List<UsuarioModel> _lstOriginalUsuarios = new List<UsuarioModel>();

        private ObservableCollection<UsuarioModel> _lstUsuarios = new ObservableCollection<UsuarioModel>();

        private UsuarioModel _UsuarioActual = null;

        #endregion

        #region Propiedades

        public ICommand GuardarUsuarioCommand { get; set; }

        public ICommand EditarUsuarioCommand { get; set; }

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
        }

        private async void InicializarClase()
        {
            LstUsuarios = await UsuarioModel.SeleccionarTodos();
            _lstOriginalUsuarios = LstUsuarios.ToList();
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

                if (_UsuarioActual == null) await UsuarioModel.Insertar(objUsuario);
                else await UsuarioModel.Actualizar(objUsuario);

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Usuarios", "No fue posible insertar el usuario!", "OK");
            }
        }

        private void EditarUsuario(UsuarioModel usuario)
        {
            _UsuarioActual = usuario;

            Usuario = usuario.Usuario;
            Contrasenna = usuario.Contrasenna;
            Estado = Convert.ToBoolean(usuario.Estado);
        }

        private void FiltrarLista(string filtro)
        {
            LstUsuarios.Clear();
            _lstOriginalUsuarios.Where(x => x.Usuario.ToLower().Contains(filtro.ToLower())).ToList().ForEach(x => LstUsuarios.Add(x));
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
