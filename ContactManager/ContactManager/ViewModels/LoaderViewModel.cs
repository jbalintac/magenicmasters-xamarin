using ContactManager.Model;
using ContactManager.Services;
using ContactManager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace ContactManager.ViewModels
{
    public class LoaderViewModel : INotifyPropertyChanged
    {
        string loadingStatus = "";
        List<Contact> contacts;
        bool proceedVisible;
        readonly DataService dataService = new DataService();

        public event PropertyChangedEventHandler PropertyChanged;

        // Constructor
        public LoaderViewModel()
        {
            Proceed = new Command<string>(async (key) =>
            {
                var page = new ContactList();
                contacts.ForEach(c => ((ContactListViewModel)page.BindingContext).Contacts.Add(c));

                await Navigation.PushAsync(page);
                // Add the key to the input string.
            });



            Task.Run(async () => await LoadDataAsync());
        }

        public async Task LoadDataAsync()
        {
            LoadingStatus = "Downloading Contacts...";
            ProceedVisible = false;

            var result = await dataService.GetContacts();
            contacts = result.Contacts;

            if (result.IsSuccessStatusCode)
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => {
                    var page = new ContactList();
                    contacts.ForEach(c => ((ContactListViewModel)page.BindingContext).Contacts.Add(c));
                    await Navigation.PushAsync(page);
                });

                return;
            }

            LoadingStatus = "An error occured while downloading your contacts";
            ProceedVisible = true;
        }

        public bool ProceedVisible
        {
            protected set
            {
                if (proceedVisible != value)
                {
                    proceedVisible = value;
                    OnPropertyChanged("ProceedVisible");
                }
            }
            get { return proceedVisible; }
        }

        public string LoadingStatus
        {
            protected set
            {
                if (loadingStatus != value)
                {
                    loadingStatus = value;
                    OnPropertyChanged("LoadingStatus");
                }
            }
            get { return loadingStatus; }
        }

        // ICommand implementations
        public ICommand Proceed { protected set; get; }
        public INavigation Navigation { get; internal set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}