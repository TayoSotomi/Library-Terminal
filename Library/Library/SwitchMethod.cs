using Circle;

namespace Library
{
  public class SwitchMethod
  {
    //Method
    //Search by author
    public static List<Books> AuthorFinder(List<Books> Booklist)
    {
      List<Books> BooksbyAuthor = new List<Books>();
      Console.WriteLine("Please enter an authors name:");
      string result = Console.ReadLine().ToLower().Trim();

      foreach (Books book in Booklist)
      {
        if (book.Author.ToLower().Contains(result))
        {
          BooksbyAuthor.Add(book);
        }
      }
      return BooksbyAuthor;
    }
    //Bykeyword
    public static List<Books> KeyWordFinder(List<Books> Booklist)
    {
      List<Books> BooksbyKeyword = new List<Books>();
      Console.WriteLine("Please enter a title name:");
      string result = Console.ReadLine().ToLower().Trim();

      foreach (Books book in Booklist)
      {
        if (book.Title.ToLower().Contains(result))
        {
          BooksbyKeyword.Add(book);
        }
      }
      return BooksbyKeyword;
    }
    //Catergory
    public static List<Books> CategoryFinder(List<Books> Booklist)
    {
      List<Books> BooksbyCatergory = new List<Books>();
      Console.WriteLine("Please enter a category name:");
      string result = Console.ReadLine().ToLower().Trim();

      foreach (Books book in Booklist)
      {
        if (book.Category.ToLower().Contains(result))
        {
          BooksbyCatergory.Add(book);
        }
      }
      return BooksbyCatergory;
    }
    public static int NumberFinder(List<Books> Booklist)
    {
      int result = Validator.intListValidator(Booklist);
      return result;
    }
    //Return Books


    //cart
    public static List<Books> SelectedBooks(List<Books> Booklist, Books selection)
    {
          
            Console.WriteLine("Would you like to add this book to your cart?");
            while (true)
            {
                string result = Console.ReadLine().Trim().ToLower();
                if (result == "yes"&& selection.Status == true)
                {
                    Booklist.Add(selection);
                    Console.WriteLine($"{selection.Title} has been added to your cart.");
                    break;
                }
                else if (result == "no")
                {
                    Console.WriteLine("Book not added.");
                    break;
                }
                else if (selection.Status == false)
                {
                    Console.WriteLine("The Book is not available as it is checked out.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter yes or no.");
                }
            }
      Console.WriteLine($"There are {Booklist.Count} Books in this cart");
      foreach (Books B in Booklist.OrderBy(B => B.Title))
      {
        Console.WriteLine(B.GetInfo());
      }

      return Booklist;

    }


        //Change Status
        public static List<Books> ChangeStatus(List<Books> CheckedOutBooks)
        {
            foreach (Books book in CheckedOutBooks)
            {
                book.Status = false;
            }
            return CheckedOutBooks;
        }
        
    public static void ReturnBookM(List<Books> CheckedOutBooks)
    {
      foreach (Books book in CheckedOutBooks)
      {
        book.Status = true;
      }
      //Mike^
    }


    //Change Status
    public static void CheckOutM(ref List<Books> AvailableBooks)
    {
      foreach (Books book in AvailableBooks)
      {
        book.Status = false;
        book.Due = Books.GetDueDate(DateTime.Now);
      }
      //Mike^
    }
  }
}
