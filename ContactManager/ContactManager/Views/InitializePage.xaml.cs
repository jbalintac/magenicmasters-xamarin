using ContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InitializePage : ContentPage
    {
		public InitializePage ()
		{
			InitializeComponent();

            var model = new LoaderViewModel();
            model.Navigation = Navigation;

            BindingContext = model;
        }
    }
}