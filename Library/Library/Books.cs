using System.Security.Cryptography.X509Certificates;

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
      return (String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{Title}", Author, Category, IsAvailable()));
    }
    public string GetInfoCheckOut()
    {
      return (String.Format("{0,-50}{1,20}{2,15}{3,18}", $"{Title}", Author, Category, Due.ToShortDateString()));
    }
    public static DateTime GetDueDate(DateTime checkOutDate)
    {
      DateTime dueDate = checkOutDate.AddDays(13);
      return dueDate;
    }
    public double GetDateCount(DateTime dueDate, DateTime checkOutDate)
    {
      DateTime due = dueDate;
      DateTime check = checkOutDate;
      dueDate.Subtract(checkOutDate);
      var c = due.Subtract(check);
      double x = c.Days;
      return x; //returned variable will be called date count and an int
    }

    public static int GetRandomEditMinMax(int x, int min, int max)
    {
      Random r = new Random();
      return r.Next(min, max);
    }

    public static string PickName()
    {
      int random = Books.GetRandomEditMinMax(1, 1, 6);
      string name = "";
      if (random == 1 || random == 6)
      {
        name = "Agustus";
      }
      else if (random == 2 || random == 4)
      {
        name = "Octavio";
      }
      else if (random == 3 || random == 5)
      {
        name = "Caesarion";
      }
      return name;
    }

    public static Books RandomBook(List<Books> Booklist)
    {
      int i = 1;
      int random = Books.GetRandomEditMinMax(1, 1, Booklist.Count);

      if (random >= 1 || random <= Booklist.Count)
      {
        
        i++;
      }
            //return $"{i}. {Booklist[random].Title}, {Booklist[random].Author}, {Booklist[random].Category}, {Booklist[random].IsAvailable()}";
            return Booklist[i];
    }
      public string IsAvailable()
      {
        if (Status == true)
        {
          return "On Shelf";
        }
        else
        {
          return "Not On Shelf";
        }
      }

    }
  }











