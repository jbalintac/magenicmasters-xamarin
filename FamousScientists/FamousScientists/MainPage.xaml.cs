using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FamousScientists
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent(); 
        }

        private void ViewCell_Clicked(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            var grid = (Grid)viewCell.View;
            var label = (Label)grid.Children.First();

            App.Current.MainPage.Navigation.PushAsync(new Detail(label.Text));
        }
    }
}
