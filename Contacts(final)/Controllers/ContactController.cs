using Contact.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Contact.Controllers
{
    public class ContactController
    {
        public Contact[] contacts;
        public User user;

        public ContactController(User user)
        {
            this.user = user;
            contacts = new Contact[user.contacts.Length];
        }

        public void AddContact(Contact contact)
        {
            this.user.contacts[contacts.Length - 1] = contact;
            Array.Resize(ref contacts, contacts.Length + 1);
        }

        public void AddContact(string firstName, string lastName, string phoneNumber)
        {
            this.user.contacts[0] = new Contact(firstName, phoneNumber, lastName);
            Array.Resize(ref contacts, contacts.Length + 1);
        }

        public void UpdateContact(int contactIndex)
        {

        }

        public void DeleteContact(int contactIndex)
        {

        }


    }
}
