using PRODUX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PRODUX.View.Cliente
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaCliente : ContentPage
	{
		public ConsultaCliente ()
		{
			InitializeComponent ();

            BindingContext = ClienteViewModel.GetInstance();
		}
	}
}