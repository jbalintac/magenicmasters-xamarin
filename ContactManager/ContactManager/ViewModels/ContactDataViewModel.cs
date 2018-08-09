using ContactManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.ViewModels
{
    public class ContactDataViewModel
    {
        public List<Contact> Contacts { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }
}
