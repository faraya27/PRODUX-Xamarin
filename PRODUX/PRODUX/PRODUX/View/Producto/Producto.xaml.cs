﻿using PRODUX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PRODUX.View.Producto
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Producto : ContentPage
	{
		public Producto ()
		{
			InitializeComponent ();

            BindingContext = ProductoViewModel.GetInstance();
		}
	}
}