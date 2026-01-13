
using System;
using System.Collections.Generic;
using System.Text;

namespace Contact
{
    public class Contact
    {
        public string firstName, phoneNumber, lastName;

        public Contact(string firstName, string lastName, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }
    }
}
