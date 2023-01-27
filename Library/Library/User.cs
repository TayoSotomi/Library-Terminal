using System;
using System.Collections.Generic;
using System.Linq;
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
        //public void ViewBooks(Books book);
        //public void CheckoutBooks(Books book);
        //public void ReturnBooks(Books book);



    }
}
