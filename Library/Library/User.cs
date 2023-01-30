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
            Console.WriteLine("Enjoy your first visit! What is your name?");
            while (true)
            {
                string name = Console.ReadLine().Trim();
                Console.WriteLine($"Are you happy with {name} for your username?");
               string result = Console.ReadLine().ToLower().Trim();
                if(result == "yes")
                {
                    Console.WriteLine($"Welcome {name}!");
                    return name;
                }else if(result == "no")
                {
                    Console.WriteLine("Please enter your preferred username.");
                }
                else
                {
                    Console.WriteLine("Please type yes or no.");
                }
            }
        }
        public static string returningUser(List<User> UserList)
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine("Please enter your username");
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
            bool pass = true;
            Console.WriteLine("Create your password.\n\tA password should be a combination of letters and numbers.\nYour password is case-sensitive and must be at least 10 characters long and cannot start with a space.");

            while (true)
            {
                string password = Console.ReadLine().Trim();
                if (password.Length < 3)
                {
                    Console.WriteLine($"Passwords must 3 characters or longer and not begin with a space please try again.");
                }
                else
                {
                    while (pass)
                    {
                        Console.WriteLine($"You have entered {password} for your password. Is that correct?\nType \"Y\" to confirm your password or type \"N\" to enter a new password.");
                        string choice = Console.ReadLine().Trim().ToLower();
                        if (choice == "y")
                        {
                            Console.WriteLine("Fantastic.\nRemember here at the Mouseion, we will never ask you for your account password.  We may ask for your account number, but never for your password.\nIf you receive an email that appears to be from MouseionIOH.edu and asks you for your account, it is not from us, so do not respond,\n and contact our support team to let us know at CampusLibrary.MIOH.edu.\nOur organizations carry sensitive information such as a donor’s contact information and address. We have security measures installed that keep your information\nprivate and accessible only by your volunteers.");
                            return password;
                        }
                        else if (choice == "n")
                        {
                            pass = true;

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
                string result = Console.ReadLine().Trim();
                if (result == y[x].Password)
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
