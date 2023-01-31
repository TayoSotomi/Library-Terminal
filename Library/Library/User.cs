using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class User
    {
        //Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CheckedOutBooks { get; set; }
        //Constuctor

        public User(string _username, string _password, string _checkedOutBooks)
        {
            UserName = _username;
            Password = _password;
            CheckedOutBooks = _checkedOutBooks;
        }
        
        //Methods
        public static string newUserName()
        {
            Console.WriteLine("I hope you're enjoying your first visit!\nWhat is your name?");
            while (true)
            {
                string name = Console.ReadLine().Trim();
        Console.Clear();
                Console.WriteLine($"Are you happy with {name} as your username? Type yes to confrim or no to enter a new one.");
               
                while (true)
                {
                    string result = Console.ReadLine().ToLower().Trim();
                    if (result == "yes")
                    {
                        Console.WriteLine($"Welcome {name}!");
                        return name;
                    }
                    else if (result == "no")
                    {
                        Console.WriteLine("Please enter your preferred username.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please type yes or no.");
                    }
                }
                
            }
        }
        public static string returningUser(List<User> UserList)
        {
            int i = 0;
            while (true)
            {
        Console.Clear();
                Console.WriteLine("Welcome back. Please enter your username");
                string result = Console.ReadLine().Trim();

                if (UserList.Any(x=>x.UserName == result))
                {
                     return result;
                }
                else if (i == 3)
                {
                    return "No Username found.";
                }
                else
                {
                     Console.WriteLine($"No user found by name of {result} please try again");
                }
                
            }
            
        }
        public static string CheckoutBooks(Books book, ref string result)
        {
           
            return result += ($"{book.Title}%");
        }
        //public void ReturnBooks(Books book);
        public static string newPassword()
        {
            
            Console.WriteLine("Create your password.\nA password can be a combination of letters and numbers.\nYour password is case-sensitive and must be at least 3 characters long and cannot start with a space.");

            while (true)
            {
                bool pass = true;
                //string password = Console.ReadLine().Trim();
                //System.Console.Write("password: ");
                string password = null;
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    password += key.KeyChar;
                }
                if (password.Length < 3 || password.StartsWith(" "))
                {
                    Console.WriteLine($"Passwords must be 3 characters or longer, cannot begin with a space, and must now be typed with blood of your first born child on your fingers.\nPlease try again.");
                }
                else
                {
                    while (pass)
                    {
                        Console.WriteLine($"You have entered {password} for your password. Is that correct?\nType \"Yes\" to confirm your password or type \"No\" to enter a new password.");
                        string choice = Console.ReadLine().Trim().ToLower();
                        if (choice == "yes")
                        {
              Console.WriteLine("Remember, here at the Mouseion Institute of History, we will never ask you for your account password. Our staff may ask\nfor your username or email address, " +
"but never for your password.\n\nIf you receive an email that appears to be from CampusLibrary@MIOH.edu asking for your account password, it is not from us, so\nplease do not respond " +
"and contact our team, to let us know at CampusLibrary@MIOH.edu. so we can protect others.\n\nOur organization keeps sensitive user information such as a user’s contact information " +
"and address. We are also the\nlargest unarchived repository of information in all of Western Civilization, possibly the world. While we do have\nsecurity measures installed that keep that " +
"information safe, once again our content library IS NOT archived and\nour works are not found elsewhere in the world.\n\nThe survival of our libraries content is detrimental to the surivial " +
"of the human race as a whole, so please do share\nany personal information with outside parties so we can prevent any breaches.\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

              Console.WriteLine("Once you have finished reading the above, please press any key to continue.");
              Console.ReadKey();
              Console.Clear();
              Console.WriteLine("Fantastic." +
                "\n\nPlease be aware, any breach of the system due to user negligence, will constitute an act of unspeakable treason\nagainst the world carried out by that user. This act is punishable" +
                " by means of torture and other unimaginably horrific,\nbut yet still morally just punishments. There will be no mercy." +
                "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
              Console.WriteLine("Once you have finished reading the above and acknowleged you understand, please press any key to continue.");
              Console.ReadKey();
              Console.Clear();
              return password;
                        }
                        else if (choice == "no")
                        {
                            pass = false;

                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Try again.");
                        }
                    }
                   
                }
            }
        }
        public static bool returningPassword(int x, List<User> y) 
        {
            int i = 0;
            Console.WriteLine("Please enter your password.");
            while (true)
            {
                string password = null;
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    password += key.KeyChar;
                }
                if (password == y[x].Password)
                {
                    return true;
                }
                else if (i == 3)
                {
                    Console.WriteLine("Password incorrect too many times.");
                    return false;
                }
                else
                {
                    Console.WriteLine("Password incorrect try again.");
                    i++;
                }
            }
        }
        public static List<Books> ReturnUserBooks(List<Books> allCheckedOut, List<User> allUsers, int indexUser)
        {
            List<Books> checkedOutBooks = new List<Books>();
            string[] bookNames = allUsers[indexUser].CheckedOutBooks.Split("%");

            foreach (Books books in allCheckedOut)
            {
                if (books.Status == false && bookNames.Contains(books.Title))
                {
                    checkedOutBooks.Add(books);
                    //SwitchMethod.ReturnBookM(selectedBooks);

                    Console.WriteLine($"{books.Title} due {books.Due}");
                    //filler = Validator.GetContinue($"Alright, I have returned that book for you. Would you like to return anymore books?");
                }
            }
            return checkedOutBooks;
        }


    }
}
