using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class User
    {
        //Properties
        public string UserName { get; set; }
        private string Password { get; set; }
        public List<Books> Books { get; set; }
        //Constuctor

        public User(string _username, string _password)
        {
            UserName = _username;
            Password = _password;
        }
        
        //Methods
        public abstract void ViewBooks(Books book);
        public abstract void CheckoutBooks(Books book);
        public abstract void ReturnBooks(Books book);



    }
}
