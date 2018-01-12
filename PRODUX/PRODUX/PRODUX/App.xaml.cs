using PRODUX.Model;
using PRODUX.View;
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

            //List<UsuarioModel> lstUsuarios = UsuarioModel.ObtenerUsuarioRealm();
            UsuarioModel usuario = UsuarioModel.ObtenerUsuarioRealm();

            //if (lstUsuarios.Count > 0)
            if (usuario != null)
            {
                
                PRODUX.ViewModel.Globales.UsuarioActivo = usuario.Usuario;

                NavigationPage navigation = new NavigationPage(new PRODUX.View.Menu.Inicio());
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
