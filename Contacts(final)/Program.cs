

using Contact.Controllers;
using Contact.Models;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace Contact
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string? readResult;
            string menuSelection = "";
            UserController userController = new UserController();
            User user = new User("Default", "User");
            ContactController contactController = new ContactController(user);

            //Profile nijat = new Profile("nijat", "qwerty90");
            //Profile ali = new Profile("ali", "qwerty901");
            //Profile vusal = new Profile("vusal", "qwerty902");
            //Profile seyyad = new Profile("seyyad", "qwerty903");

            //Contact new_contact = new Contact("nijat", "qurbanov", "+994504949494");
            Contact contact = new Contact("Nicat", "Qurbanov", "+994504801601");
            contactController.AddContact(contact);
            Console.WriteLine(user.contacts[0].phoneNumber);

            User new_user = new User("Zulfuqar","qwerty90");
            contactController = new ContactController(new_user);
            Contact contact1 = new Contact("Ali","Qarashli","+994505050500");
            contactController.AddContact(contact1);
            Console.WriteLine(new_user.contacts[0].phoneNumber);
            contactController = new ContactController(user);
            contactController.AddContact(contact1);
            Console.WriteLine(user.contacts[1].phoneNumber);
           


            do
            {
                Console.WriteLine("Welcome. Choose option:\n1.Sign in.\n2.Sign up.\n");
                Console.WriteLine("Enter exit to leave application.");
                readResult = Console.ReadLine();
                if (readResult != null)
                    menuSelection = readResult.ToLower();

                switch (menuSelection)
                {
                    case "1":

                        Console.WriteLine("Create nickname and password separated by comma (,)\nRequirements: \n" +
                                        "1. The nickname should consist of at least 3 characters and at most 20 characters.\n" +
                                        "2. The password should contain at least one symbol, and one number.\n" +
                                        "\tThe minimum length of password is: 6\n" +
                                        "\tThe maximum length of password is: 20\n");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            userController.AddUser(readResult);
                            contactController = new ContactController(userController.users[0]);
                        }
                           

                        break;
                    case "2":
                        Console.WriteLine("Enter nickname and password, separated by comma (,)");
                        readResult = Console.ReadLine();
                        
                        if (readResult != null)
                        {
                            if (userController.FindUser(readResult))
                            {
                                Console.WriteLine(contactController.user.contacts[0].phoneNumber);
                            }
                        }

                        break;
                }

            } while (menuSelection != "exit");







            //ContactController contactController = new ContactController(profileController.profiles[0]);
            //contactController.AddContact(new_contact);



        }
    }
}