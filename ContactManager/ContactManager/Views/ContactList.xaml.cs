﻿using ContactManager.Interfaces;
using ContactManager.Models;
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
    public partial class ContactList : TabbedPage
    {

        public ContactList (IDialerService dialerService)
        {
            InitializeComponent();
            var model = new ContactListViewModel(dialerService);
            model.Navigation = Navigation;

            model.SwitchToDialPage = () =>
            {
                CurrentPage = Children[1];
            };
            
            BindingContext = model;
        }
    }
}