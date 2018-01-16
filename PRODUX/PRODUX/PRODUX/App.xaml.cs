using PRODUX.Model;
using PRODUX.View;
using PRODUX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PRODUX
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //UsuarioModel.EliminarUsuarioRealm();

            //List<UsuarioModel> lstUsuarios = UsuarioModel.ObtenerUsuarioRealm();
            //UsuarioModel usuario = new UsuarioModel();
            UsuarioModel usuario = UsuarioModel.ObtenerUsuarioRealm();

            //if (lstUsuarios.Count > 0)
            if (usuario != null)
            {                
                Globales.UsuarioActivo = usuario.Usuario;

                NavigationPage navigation = new NavigationPage(new PRODUX.View.Menu.Inicio());
                navigation.CurrentPage.Title = Globales.UsuarioActivo;
                navigation.BarBackgroundColor = Color.Black;
                navigation.BarTextColor = Color.White;

                MainPage = new MasterDetailPage
                {
                    Master = new PRODUX.View.Menu.Menu(),
                    Detail = navigation
                };
            }
            else
            {
                MainPage = new InicioSesion();
            }            
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
