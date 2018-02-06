using LuizalabsEmployeeManager.Helpers;
using System;
using System.Text.RegularExpressions;

namespace LuizalabsEmployeeManager.Domain.ValueObjects
{
    public class Email
    {
        public const int AddressMaxLength = 254;
        public string Address { get; private set; }

        //Entity Framework
        protected Email()
        {

        }

        public Email(string address)
        {
            Guard.ForNullOrEmptyDefaultMessage(address, "E-mail");
            Guard.StringLength("E-mail", address, AddressMaxLength);

            if (IsValid(address) == false)
                throw new Exception("Invalid E-mail");

            Address = address;
        }

        public static bool IsValid(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
