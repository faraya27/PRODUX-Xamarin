using PRODUX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PRODUX.View.Pedido
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Pedido : ContentPage
	{
		public Pedido ()
		{
			InitializeComponent ();

            BindingContext = PedidoViewModel.GetInstance();
		}
	}
}