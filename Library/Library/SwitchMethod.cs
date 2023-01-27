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
        public static List<Books> ReturnBook(List<Books> list)
        {
            List<Books> CheckedOutBooks = new List<Books>();
            foreach (Books book in list)
            {
                if (book.Status == true)
                {
                    CheckedOutBooks.Add(book);

                }
            }
            return CheckedOutBooks;
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
    }
}
