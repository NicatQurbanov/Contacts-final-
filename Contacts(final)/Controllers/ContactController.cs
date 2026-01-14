using Contact.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
            contacts = new Contact[1];
        }

        private string[] ProcessInput(string input)
        {
            string[] userInput = input.Split(",");
            if (userInput.Length == 3)
            {
                string[] processedInput = new string[userInput.Length];

                for (int i = 0; i < userInput.Length; i++)
                {
                    processedInput[i] = userInput[i].Trim();
                }

                return processedInput;
            }
            return null;
        }

        public bool CheckID(int index)
        {
            if (index >= this.user.contacts.Length || index < 0)
            {
                Console.WriteLine("Invalid ID");
                return false;
            }
            else
                return true;
        }

        private bool CheckNumber(string number)
        {
            if (Regex.IsMatch(number, "^\\+994(50|51|55|70|77|99)\\d{7}$"))
                return true;
            else
                Console.WriteLine("Invalid number.");
            return false;
        }

        public void Animation(int sleep)
        {
            string[] loadingText = ["Loading", "lOading", "loAding", "loaDing", "loadIng", "loadiNg", "loadinG"];
            int count = 0;
            do
            {
                foreach (string s in loadingText)
                {
                    Console.Write($"\r{s}...");
                    Thread.Sleep(sleep);
                }
                count++;
            } while (count != 3);

            Console.Write($"\r{new string(' ', Console.BufferWidth)}");
        }

        public void AddContact(Contact contact)
        {
            if(CheckNumber(contact.phoneNumber))
            {
                this.user.contacts[this.user.contacts.Length - 1] = contact;
                Array.Resize(ref this.user.contacts, this.user.contacts.Length + 1);
            }
        }

        public void AddContact(string firstName, string lastName, string phoneNumber)
        {
            if (CheckNumber(phoneNumber))
            {
                this.user.contacts[this.user.contacts.Length - 1] = new Contact(firstName, lastName, phoneNumber);
                Array.Resize(ref this.user.contacts, this.user.contacts.Length + 1);
            }
        }

        public void AddContact(string input)
        {
            string[] processedInput = ProcessInput(input);

            if (CheckNumber(processedInput[2]))
            {
                this.user.contacts[this.user.contacts.Length - 1] = new Contact(processedInput[0], processedInput[1], processedInput[2]);
                Array.Resize(ref this.user.contacts, this.user.contacts.Length + 1);
                Console.Clear();
                Console.WriteLine($"You added {processedInput[0]} to your contact list!");
            }
        }

        public void ShowContacts(User user)
        {
            if (user.contacts.Length == 1 && user.contacts[0] == null)
                Console.WriteLine("Add contacts to begin with.\n");
            else
            {
                foreach (Contact contact in this.user.contacts)
                {
                    if (contact == null) continue;
                    Console.WriteLine($"\n``````````````````````{Array.IndexOf(this.user.contacts, contact) + 1}``````````````````````\n" +
                                      $"First name:\t\t{contact.firstName}\n" +
                                      $"Last name:\t\t{contact.lastName}\n" +
                                      $"Telephone number:\t{contact.phoneNumber}\n" +
                                      $"`````````````````````````````````````````````");
                }
            }
                
        }

        public void UpdateContactNumberByID(int index, string number)
        {
            Console.Clear();
            Animation(70);
            if (CheckID(index))
                this.user.contacts[index - 1].phoneNumber = number;
        }

        public void UpdateContactLastNameByID(int index, string lastName)
        {
            Console.Clear();
            Animation(30);
            if (CheckID(index))
                this.user.contacts[index - 1].lastName = lastName;
        }

        public void UpdateContactFirstNameByID(int index, string firstName)
        {
            Console.Clear();
            Animation(60);
            if (CheckID(index))
                this.user.contacts[index - 1].firstName = firstName;
        }

        public void DeleteContact(string contactIndex)
        {
            Console.Clear();
            Animation(60);
            int.TryParse(contactIndex, out int index);
            if(CheckID(index))
                this.user.contacts[index - 1] = null;
        }
    }
}
