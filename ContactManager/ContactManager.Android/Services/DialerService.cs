using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ContactManager.Interfaces;
using Xamarin.Forms;

namespace ContactManager.Droid.Services
{
    public class DialerService : IDialerService
    {
        public void DialPhoneNumber(string phoneNumber)
        {
            var number = Android.Net.Uri.Parse("tel:" + phoneNumber);
            var context = Android.App.Application.Context;
            var dialintent = new Intent(Intent.ActionView, number);
            context.StartActivity(dialintent);
        }
    }
}