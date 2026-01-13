
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

        public void AddUser(User profile = null)
        {
            this.users[0] = profile;
            Array.Resize(ref users, users.Length + 1);
        }

        public void AddUser(string input)
        {
            string[] processedInput = ProcessInput(input);

            if (Regex.IsMatch(processedInput[0], "^[a-zA-Z0-9_]{2,20}$") && Regex.IsMatch(processedInput[1], "^(?=.*[a-z])(?=.*\\d)(?=.*[^a-zA-Z0-9])[^\\s]{6,20}$"))
            {
                if (!FindUserByNickname(processedInput[0]))
                {
                    this.users[0] = new User(processedInput[0], processedInput[1]);
                    Array.Resize(ref users, users.Length + 1);
                    Console.WriteLine("You are signed in!");
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
                        Console.WriteLine($"Welcome, {users[i].nickname}!");
                        return true;
                    }
                }
            Console.WriteLine("Incorrect name and/or password input.");
            return false;
        }

        private string[] ProcessInput(string input)
        {
            string[] userInput = input.Split(",");
            string[] processedInput = new string[userInput.Length];

            for (int i = 0; i < userInput.Length; i++)
            {
                processedInput[i] = userInput[i].Trim();
            }

            return processedInput;
        }


    }
}
