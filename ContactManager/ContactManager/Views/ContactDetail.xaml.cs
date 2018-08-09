using ContactManager.Model;
using ContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetail : ContentPage
	{
		public ContactDetail ()
		{
            InitializeComponent();

            var model = new ContactDetailViewModel();
            model.Contacts = new ObservableCollection<Contact>();
            model.Contact = new Contact();
            model.Navigation = Navigation;
            model.DisplayAlert = DisplayAlert;

            BindingContext = model;
        }
	}
}