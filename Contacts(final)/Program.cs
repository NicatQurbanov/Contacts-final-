

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
            string? thisUser;
            UserController userController = new UserController();
            
            User nijat = new User("nijat", "qwerty90@");
            User ali = new User("ali", "12345a!");
            
            userController.AddUser(nijat);
            userController.AddUser(ali);
            
            ContactController contactController = new ContactController(nijat);
            contactController.AddContact("vusal","hacixelilov","+994503211233");
            contactController.AddContact("seyyad","babazade", "+994503211233");
            contactController.AddContact("sadiq", "axundov", "+994502098010");
            
            contactController = new ContactController(ali);
            contactController.AddContact("nihat", "huseynli", "+994512092156");
            contactController.AddContact("mehemmed", "bayramov", "+994500981212");

            do
            {
                userController.Entry();
                readResult = Console.ReadLine();
                if (readResult != null)
                    menuSelection = readResult.ToLower();

                switch (menuSelection)
                {
                    case "1":

                        userController.SignIn();
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            userController.AddUser(readResult);
                            contactController = new ContactController(userController.GetUser(readResult));
                        }
                            break;

                    case "2":
                        userController.SignUp();
                        thisUser = Console.ReadLine();

                        if (thisUser != null)
                        {
                            if (userController.FindUser(thisUser))
                            {
                                contactController.ShowContacts(userController.GetUser(thisUser));
                                Console.WriteLine("Choose option:\n1.Add contact\n2.Update contact\n3.Delete contact");
                                readResult = Console.ReadLine();

                                if (readResult != null)
                                    menuSelection = readResult;

                                switch(menuSelection)
                                {
                                    case "1":

                                        Console.WriteLine("Write contact's first name, last name and phone number separated by comma respectively.");

                                        break;
                                    case "2":

                                        Console.WriteLine("Enter ID of the contact you want to modify.");
                                        readResult = Console.ReadLine();

                                        int index = 0;
                                        if (readResult != null)
                                            int.TryParse(readResult, out index);
                                        userController.Animation(90);

                                        if (contactController.CheckID(index))
                                        {
                                            Console.WriteLine("Choose option:\n1.Update first name\n2.Update last name\n3.Update phone number\n");
                                            readResult = Console.ReadLine();
                                            if (readResult != null)
                                                menuSelection = readResult;

                                            switch (menuSelection)
                                            {
                                                case "1":

                                                    Console.WriteLine("Enter the new first name.");
                                                    readResult = Console.ReadLine();

                                                    if (readResult != null)
                                                        contactController.UpdateContactFirstNameByID(index, readResult);

                                                    contactController.ShowContacts(userController.GetUser(thisUser));
                                                    break;
                                                case "2":

                                                    Console.WriteLine("Enter the new last name.");
                                                    readResult = Console.ReadLine();

                                                    if (readResult != null)
                                                        contactController.UpdateContactLastNameByID(index, readResult);

                                                    contactController.ShowContacts(userController.GetUser(thisUser));
                                                    break;
                                                case "3":

                                                    Console.WriteLine("Enter the new phone number.");
                                                    readResult = Console.ReadLine();

                                                    if (readResult != null)
                                                        contactController.UpdateContactNumberByID(index, readResult);

                                                    contactController.ShowContacts(userController.GetUser(thisUser));
                                                    break;

                                            }
                                        }
                                        break;
                                        
                                    case "3":

                                        Console.WriteLine("Enter ID of the contact you want to delete.");
                                        readResult= Console.ReadLine();

                                        if (readResult != null)
                                            contactController.DeleteContact(readResult);

                                        contactController.ShowContacts(userController.GetUser(thisUser));
                                        break;
                                }
                            }
                        }
                        break;
                }
            } while (menuSelection != "exit");
        }
    }
}
