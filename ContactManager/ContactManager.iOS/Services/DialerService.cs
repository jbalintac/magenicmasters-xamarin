using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManager.Interfaces;
using Foundation;
using UIKit;

namespace ContactManager.iOS.Services
{
    public class DialerService : IDialerService
    {
        public void DialPhoneNumber(string phoneNumber)
        {
            var url = new NSUrl($"tel:{phoneNumber}");
            UIApplication.SharedApplication.OpenUrl(url);
        }
    }
}