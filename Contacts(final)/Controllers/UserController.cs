using Contact.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Contact.Controllers
{
    public class UserController
    {
        public User[] users;
        public UserController()
        {
            this.users = new User[1];
        }

        public void AddUser(User profile)
        {
            this.users[users.Length - 1] = profile;
            Array.Resize(ref users, users.Length + 1);
        }

        public void AddUser(string nickname, string password)
        {
            this.users[users.Length - 1] = new User(nickname, password);
            Array.Resize(ref users, users.Length + 1);
        }

        public User GetUser(string input)
        {
            if (input != null)
            {
                string[] processedInput = ProcessInput(input);

                if (users.Length == 1 && users[0] == null)
                {
                    Console.WriteLine("There are no users.");
                    return null;
                }

                else
                    for (int i = 0; i < users.Length; i++)
                    {
                        if (users[i] == null) continue;
                        else if (users[i].nickname == processedInput[0] && users[i].password == processedInput[1])
                        {
                            return users[i];
                        }
                    }
            }
            else
            {
                Console.WriteLine("Incorrect name and/or password input.");
                return null;
            }
            return null;
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

        public void AddUser(string input)
        {
            if (input != null)
            {
                string[] processedInput = ProcessInput(input);

                if (Regex.IsMatch(processedInput[0], "^[a-zA-Z0-9_]{2,20}$") && Regex.IsMatch(processedInput[1], "^(?=.*[a-z])(?=.*\\d)(?=.*[^a-zA-Z0-9])[^\\s]{6,20}$"))
                {
                    if (!FindUserByNickname(processedInput[0]))
                    {
                        this.users[users.Length - 1] = new User(processedInput[0], processedInput[1]);
                        Array.Resize(ref users, users.Length + 1);
                        Animation(70);
                        Console.WriteLine("You are signed in!");
                    }
                }
            }
            else
                Console.WriteLine("The password or/and nickname are not qualified.");
        }

        public bool FindUserByNickname(string input)
        {
                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i] == null )
                        continue;

                    else if (users[i].nickname == input)
                    {
                        Console.WriteLine("This nickname is already present.");
                        return true;
                    }
                        
                }
            return false;
        }

        public bool FindUser(string input)
        {
            if (input != null)
            {
                string[] processedInput = ProcessInput(input);

                if (users.Length == 1 && users[0] == null)
                {
                    Console.WriteLine("There are no users.");
                    return false;
                }

                else
                    for (int i = 0; i < users.Length; i++)
                    {
                        if (users[i] == null) continue;
                        else if (users[i].nickname == processedInput[0] && users[i].password == processedInput[1])
                        {
                            Console.Clear();
                            Console.WriteLine($"Welcome, {users[i].nickname}!");
                            return true;
                        }
                    }
            }
            else
            {
                Console.WriteLine("Incorrect name and/or password input.");
                return false;
            }
            return false;
        }

        private string[] ProcessInput(string input)
        {
            string[] userInput = input.Split(",");
            if (userInput.Length == 2)
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

        public void SignIn()
        {
            Console.Clear();
            Console.WriteLine("Create nickname and password separated by comma (,)\nRequirements: \n" +
                            "1. The nickname should consist of at least 3 characters and at most 20 characters.\n" +
                            "2. The password should contain at least one symbol, and one number.\n" +
                            "\tThe minimum length of password is: 6\n" +
                            "\tThe maximum length of password is: 20\n");
        }

        public void SignUp()
        {
            Console.Clear();
            Console.WriteLine("Enter nickname and password, separated by comma (,)");
        }

        public void Entry()
        {
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Choose option:\n1.Sign in.\n2.Sign up.\n");
            Console.WriteLine("Enter exit to leave application.");
        }
    }
}
