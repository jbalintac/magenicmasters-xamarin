using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ContactManager.Models
{
    [Serializable]
    public class Contact : INotifyPropertyChanged
    {
        private string firstName;

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

        private string lastName;

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

        private string contactNumber;

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




        private bool isFavorite;

        public bool IsFavorite
        {
            set
            {
                if (isFavorite != value)
                {
                    isFavorite = value;
                    OnPropertyChanged("IsFavorite");
                    OnPropertyChanged("IsNotFavorite");
                }
            }
            get { return isFavorite; }
        }


        public bool IsNotFavorite
        {
            get { return !isFavorite; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
