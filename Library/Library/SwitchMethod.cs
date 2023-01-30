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
      int result = Validator.intValidator(Booklist);
      return result;
    }
    //Return Books


        //cart
 public static List<Books> SelectedBooks(List<Books>Booklist,Books selection)
        {
            //Adds selection to Booklist
            Booklist.Add(selection);
            Console.WriteLine($"There are {Booklist.Count} Books in this cart");

            //Displays books in Booklist
            //sorts books in Booklist in Alphabetical order
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
    public static void CheckOutM(List<Books> AvailableBooks)
    {
      foreach (Books book in AvailableBooks)
      {
        book.Status = false;
      }
      //Mike^
    }
  }
}
