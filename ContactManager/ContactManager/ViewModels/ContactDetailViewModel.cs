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
using System.Linq;
using System.Text.RegularExpressions;

namespace ContactManager.ViewModels
{
    public class ContactDetailViewModel : INotifyPropertyChanged
    {
        string firstName = "";
        string lastName = "";
        string contactNumber = "";

        readonly DataService dataService = new DataService();

        public ObservableCollection<Contact> Contacts { get; set; }
        public Contact Contact { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        // Constructor
        public ContactDetailViewModel()
        {
            SaveContact = new Command<string>(async (key) =>
            {
                var contact = Contacts.Where(c => c == Contact).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(FirstName) ||
                    string.IsNullOrWhiteSpace(LastName) ||
                    string.IsNullOrWhiteSpace(ContactNumber)
                    )
                {
                    await DisplayAlert("", "Invalid Input: Empty field not is valid.", "Ok");
                    return;
                }

                if (!IsContactNumberValid(ContactNumber))
                {
                    await DisplayAlert("", "Invalid Input: Allowed phone number characters are 0-9 and +, *, # only.", "Ok");
                    return;
                }

                if (contact != null)
                {
                    contact.FirstName = FirstName;
                    contact.LastName = LastName;
                    contact.ContactNumber = ContactNumber;
                }
                else
                {
                    var newContact = new Contact
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        ContactNumber = ContactNumber
                    };

                    Contacts.Add(newContact);
                }

                await Navigation.PopAsync();
                // Add the key to the input string.
            });
        }


        public string FirstName
        {
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
            get { return firstName; }
        }

        public string LastName
        {
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
            get { return lastName; }
        }

        public string ContactNumber
        {
            set
            {
                if (contactNumber != value)
                {
                    contactNumber = value;
                    OnPropertyChanged("ContactNumber");
                }
            }
            get { return contactNumber; }
        }

        // ICommand implementations
        public ICommand SaveContact { protected set; get; }
        public INavigation Navigation { get; internal set; }
        public Func<string, string, string, Task> DisplayAlert { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool IsContactNumberValid(string contact)
        {
           return new Regex(@"^[0-9\*#+]+$").IsMatch(contact);
        }
    }
}