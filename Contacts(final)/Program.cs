

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
                Console.WriteLine("Choose option:\n1.Sign in.\n2.Sign up.\n");
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
                            contactController = new ContactController(userController.GetUser(readResult));
                            contactController.AddContact("nicat", "qurbanov", "+994504801601");
                        }


                        break;
                    case "2":
                        Console.WriteLine("Enter nickname and password, separated by comma (,)");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            if (userController.FindUser(readResult))
                            {
                                contactController.ShowContacts(userController.GetUser(readResult));
                            }
                        }

                        break;
                }

            } while (menuSelection != "exit");
        }
    }
}