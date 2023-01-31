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
                if (result == "yes"&& selection.Status == true && !Booklist.Any(x=>x.Title == selection.Title))
                {
                    Booklist.Add(selection);
                    Console.WriteLine($"{selection.Title} has been added to your cart.");
                    break;
                }else if (Booklist.Any(x=>x.Title == selection.Title))
                {
                    Console.WriteLine("Sorry that book is already in your cart.");
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
        
    public static void ReturnBookM(List<Books> CheckedOutBooks,List<User> allUsers, int indexUser)
    {
            bool loop = true;
            Console.WriteLine("Here are the books you currently have checked out, which book would you like to return");
            List<string> bookNames = allUsers[indexUser].CheckedOutBooks.Split("%").ToList();
            while (loop)
            {
                string result = Console.ReadLine().Trim().ToLower();

                foreach (Books book in CheckedOutBooks)
                {
                    if (book.Title.ToLower().Contains(result))
                    {
                        book.Status = true;
                        //to show the last time it was returned 
                        book.Due = DateTime.Now;
                        bookNames.Remove(book.Title);

                    }

                }

                while (true)
                {
                    Console.WriteLine("would you like to return any more books? yes/No ");
                    string answer = Console.ReadLine().Trim().ToLower();

                    if (answer == "yes")
                    {
                        Console.WriteLine("Please enter the title of the book you would like to return.");
                    }
                    else if (answer == "no")
                    {
                        loop = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                
               
            }
            string returnValue = "";
            foreach (string book in bookNames)
            {
                returnValue += book+"%";
            }
            allUsers[indexUser].CheckedOutBooks = returnValue;
            

        }


    //Change Status
    public static void CheckOutM(ref List<Books> AvailableBooks)
    {
      foreach (Books book in AvailableBooks)
      {
        book.Status = false;
        book.Due = Books.GetDueDate(DateTime.Now);
      }

    }
  }
}
