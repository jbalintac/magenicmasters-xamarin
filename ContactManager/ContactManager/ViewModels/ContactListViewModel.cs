using ContactManager.Models;
using ContactManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactManager.ViewModels
{
    class ContactListViewModel : INotifyPropertyChanged
    {
        string searchText;
        string dialpadDisplay;
        ObservableCollection<Contact> contacts;

        public ObservableCollection<Contact> DisplayedContacts
        {
            get
            {
                var filteredContacts = new ObservableCollection<Contact>(
                    Contacts?.Where(c => 
                        (c.FirstName != null && c.FirstName.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (c.LastName != null && c.LastName.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        string.IsNullOrEmpty(SearchText)
                ));

                return filteredContacts;
            }
        }

        public string SearchText
        {
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged("SearchText");
                    OnPropertyChanged("DisplayedContacts");
                }
            }
            get { return searchText; }
        }

        public string DialpadDisplay
        {
            set
            {
                if (dialpadDisplay != value)
                {
                    dialpadDisplay = value;
                    OnPropertyChanged("DialpadDisplay");
                }
            }
            get { return dialpadDisplay; }
        }

        public ObservableCollection<Contact> Contacts
        {
            set
            {
                if (contacts != value)
                {
                    contacts = value;
                    OnPropertyChanged("Contacts");
                    OnPropertyChanged("DisplayedContacts");
                }
            }
            get { return contacts; }
        }

        public ContactListViewModel()
        {

            AddContact = new Command<string>(async (key) =>
            {
                var page = new ContactDetail();
                ((ContactDetailViewModel)page.BindingContext).Contact = new Contact();
                ((ContactDetailViewModel)page.BindingContext).Contacts = Contacts;
                await Navigation.PushAsync(page);
            });

            EditContact = new Command<Contact>(async (c) =>
            {
                var page = new ContactDetail();
                ((ContactDetailViewModel)page.BindingContext).Contact = c;
                ((ContactDetailViewModel)page.BindingContext).Contacts = Contacts;

                ((ContactDetailViewModel)page.BindingContext).FirstName = c?.FirstName;
                ((ContactDetailViewModel)page.BindingContext).LastName = c?.LastName;
                ((ContactDetailViewModel)page.BindingContext).ContactNumber = c?.ContactNumber;

                await Navigation.PushAsync(page);
            });

            DeleteContact = new Command<Contact>((c) =>
            {
                Contacts.Remove(c);
            });

            FavoriteContact = new Command<Contact>((c) =>
            {
                var favoriteCount = Contacts.Count(i=> i.IsFavorite);

                if(favoriteCount < 10 || c.IsFavorite)
                    c.IsFavorite = !c.IsFavorite;
            });

            DialButtonPressed = new Command<string>((c) =>
            {
                if(string.IsNullOrWhiteSpace(c) && DialpadDisplay.Length > 0)
                {
                    DialpadDisplay = DialpadDisplay.Substring(0, (DialpadDisplay.Length - 1));
                    return;
                }

                DialpadDisplay += c; 
            });

            DialContact = new Command<Contact>((c) =>
            {
                DialpadDisplay = c.ContactNumber;
                SwitchToDialPage();
            });

            CallContact = new Command(() =>
            {
                Device.OpenUri(new Uri($"tel:{DialpadDisplay}"));
            });

            DialpadDisplay = "";
            SearchText = "";
            Contacts = new ObservableCollection<Contact>();
            Contacts.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedMethod);
        }




        public INavigation Navigation { get; internal set; }
        public ICommand AddContact { protected set; get; }
        public ICommand EditContact { protected set; get; }
        public ICommand DeleteContact { protected set; get; }
        public ICommand FavoriteContact { protected set; get; }
        public ICommand DialContact { protected set; get; }
        public ICommand CallContact { protected set; get; }
        public ICommand DialButtonPressed { protected set; get; }


        public Action SwitchToDialPage { get; internal set; }

        private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            Contacts = new ObservableCollection<Contact>(Contacts?.OrderBy(i => !i.IsFavorite)?.ThenBy(i => i.FirstName));
            Contacts.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedMethod);

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged item in e.OldItems)
                    item.PropertyChanged -= item_PropertyChanged;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged item in e.NewItems)
                    item.PropertyChanged += item_PropertyChanged;
            }

        }

        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Contacts = new ObservableCollection<Contact>(Contacts?.OrderBy(i => !i.IsFavorite)?.ThenBy(i => i.FirstName));
            Contacts.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedMethod);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
