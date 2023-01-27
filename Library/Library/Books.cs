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
    public DateTime GetDueDate(DateTime checkOutDate)
    {
      DateTime check = checkOutDate;
      DateTime dueDate = checkOutDate.AddDays(13);
      return Due;
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

    public bool GetStatus()
    {
      return Status;
    }
    public static int GetRandomEditMinMax(int x, int min, int max)
    {
      Random r = new Random();
      return r.Next(min, max);
    }
  }
}










