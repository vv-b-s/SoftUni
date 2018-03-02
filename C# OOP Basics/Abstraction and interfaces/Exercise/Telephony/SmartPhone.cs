using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class SmartPhone :ICallable, IBrowsable
    {
        private string phoneNumber;
        private string url;

        public SmartPhone(string data, bool isPhoneNumber)
        {
            if (isPhoneNumber)
                PhoneNumber = data;

            else URL = data;
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (Regex.IsMatch(value, @"^\d+$"))
                    phoneNumber = value;

                else throw new ArgumentException("Invalid number!");
            }
        }
        public string URL
        {
            get => url;
            set
            {
                if (Regex.IsMatch(value, @"^\D*$"))
                    url = value;

                else throw new ArgumentException("Invalid URL!");
            }
        }

        public string VisitURL() => $"Browsing: {URL}!";

        public string Call() => $"Calling... {phoneNumber}";
    }
}
