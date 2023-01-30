using Circle;
using Library;

FileIO.FileVerifier(); //Verifies that file is present.
PersonFileIO.PersonFileVerifier();
List<Books> unlistBooks = FileIO.FileReader();
List<Books> listBooks = unlistBooks.OrderBy(x => x.Title).ToList();
List<Books> selectedBooks = FileIO.FileReader(); //This holds the books they've selected.
List<User> userList = PersonFileIO.PersonFileReader(); //This holds the books they've selected.

//Mike^
//===================================================================================================================
//List of books
bool filler = true;
bool runProgram = true;

List<Books> Cart = new List<Books>();


Console.WriteLine($"\n\nWelcome to the Campus Library of the Mouseion Institute of History, my name is {Books.PickName()} and I will be your \nlibrarian today. Currently, " +
  $"we have {listBooks.Count} books available to check out.");
while (runProgram)
{

  int i = 1;
  foreach (Books book in listBooks)
  {
    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{i}. {book.Title}", book.Author, book.Category, book.IsAvailable()));
    i++;
  }
  Console.WriteLine("Please choose from one of the follow.\n\n" +
    "1) Search by author\n" +
    "2) Search by title keyword\n" +
    "3) Search by category\n" +
    "4) Search by number in list\n" +
    "5) Choose book at random\n" +
    "6) Return a book\n" +
    "7) Checkout");
  //Mike^

  ////List<Books> Selection = new List<Books>();
  //string selected = " ";

  int menuChoice = Validator.intValidator();
  if (menuChoice == 1)
  {
    List<Books> booksByAuthor = SwitchMethod.AuthorFinder(listBooks);
    foreach (Books book in booksByAuthor)
    {
      Console.Clear();
      Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{book.Title}", book.Author, book.Category, book.IsAvailable()));
      Cart = SwitchMethod.SelectedBooks(Cart, book);

      //  Selection = listBooks.Where(book => book.Equals(selected)).ToList();
      //Console.WriteLine(SwitchMethod.SelectedBooks(Selection));
    }
  }
  else if (menuChoice == 2)
  {
    Console.Clear();
    List<Books> booksByKeyword = SwitchMethod.KeyWordFinder(listBooks);
    foreach (Books book in booksByKeyword)
    {
      Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{book.Title}", book.Author, book.Category, book.IsAvailable()));
      Cart = SwitchMethod.SelectedBooks(Cart, book);

    }
  }
  else if (menuChoice == 3)
  {
    Console.Clear();
    List<Books> booksByCategory = SwitchMethod.CategoryFinder(listBooks);
    foreach (Books book in booksByCategory)
    {
      Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{book.Title}", book.Author, book.Category, book.IsAvailable()));
      Cart = SwitchMethod.SelectedBooks(Cart, book);
    }
  }
  else if (menuChoice == 4)
  {
    Console.Clear();
    int x = SwitchMethod.NumberFinder(listBooks);

    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", listBooks[x].Title, listBooks[x].Author, listBooks[x].Category, listBooks[x].IsAvailable()));
    Cart = SwitchMethod.SelectedBooks(Cart, listBooks[x]);
  }
  else if (menuChoice == 5) //randomnumber
  {
    Console.Clear();
    Console.WriteLine("Here is your book, I personally love this one.\n");
    Books x = Books.RandomBook(listBooks);

    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", x.Title, x.Author, x.Category, x.IsAvailable()));
    Cart = SwitchMethod.SelectedBooks(Cart, x);
    //Mike^ swapped

    Console.WriteLine("\nWould you like to choose another?");
  }
  else if (menuChoice == 6)//returnbooks
  {
    List<Books> checkedOutBooks = new List<Books>();

    Console.WriteLine("Here are the books we currently have checked out, which book would you like to return");

    foreach (Books books in selectedBooks)
    {
      if (books.Status == false)
      {
        checkedOutBooks.Add(books);
        //SwitchMethod.ReturnBookM(selectedBooks);

        Console.WriteLine(books.Title);
        //filler = Validator.GetContinue($"Alright, I have returned that book for you. Would you like to return anymore books?");
      }
    }
    SwitchMethod.ReturnBookM(checkedOutBooks);
    //Mike^
  }
  else if (menuChoice == 7)//checkout
  {
    List<Books> checkedOut = new List<Books>();
    Console.WriteLine($"\nWould you like to check out a book from your cart? \nPlease select \"Yes\" to check out the selected book or \"No\" to put it back on the shelf?");

    foreach (Books book in Cart)
    {
      Console.WriteLine($"Would you like to check out {book.Title}?");
      while (true)
      {
        string makeSelection = Console.ReadLine().ToLower().Trim();
        if (makeSelection == "yes")
        {
          checkedOut.Add(book);
          ;
          break;
        }
        else if (makeSelection == "no")
        {
          break;
        }
        else
        {
          Console.WriteLine("Please say yes or no.");
        }
      }

    }
    SwitchMethod.CheckOutM(ref checkedOut);
    foreach (Books book in checkedOut)
    {
      Console.WriteLine(book.GetInfoCheckOut());

    }

    Console.WriteLine("Have a good day.");
    runProgram = false;
  }
  Console.WriteLine("Press Enter to continue.");
  Console.ReadLine();
  Console.Clear();


}
//=================================================================================================================================

FileIO.fileWriter(listBooks);
//PersonFileIO.PersonFileReader()








