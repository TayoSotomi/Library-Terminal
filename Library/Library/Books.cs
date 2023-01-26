using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Books
    {
        //properties
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public bool Status { get; set; }
        public DateTime Due { get; set; }

        //constructors
        public Books(string _title, string _author, string _category, bool _status, DateTime _due)
        {
            Title = _title;
            Author = _author;
            Category = _category;
            Status = _status;
            Due = _due;
        }
        //method
        public string GetInfo()
        {
            return ($"{Title}|{Author}|{Category}|{Status}|{Due}");
        }
        public DateTime GetDueDate(DateTime receivedDatedTime)
        {
            DateTime checkOutDate = receivedDatedTime;
            DateTime dueDate = checkOutDate.AddDays(13);
            return dueDate;
        }

        public bool GetStatus()
        {
            return Status;
        }
    }
}
        

      

      
        
    

    

