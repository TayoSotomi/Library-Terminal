using Library;
using Circle;

FileIO.FileVerifier(); //Verifies that file is present.
PersonFileIO.PersonFileReader();
List<Books> unlistBooks = FileIO.FileReader();//reads all files and places in book class.
List<Books> listBooks = unlistBooks.OrderBy(x => x.Title).ToList();
List<Books> selectedBooks = FileIO.FileReader(); //This holds the books they've selected.
List<User> userList = PersonFileIO.PersonFileReader();
List<Books> selectedBooks = FileIO.FileReader(); //This holds the books they've selected.
//Mike^
//===================================================================================================================
//List of books
bool filler = true;

int i = 1;

foreach (Books book in listBooks)
{
  Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{i}. {book.Title}", book.Author, book.Category, book.IsAvailable()));
  i++;
}

Console.WriteLine($"\n\nWelcome to the Campus Library of the Mouseion Institute of History, my name is {Books.PickName()} and I wll be your \nlibrarian today. Currently, " +
  $"we have {listBooks.Count} books available to check out.");
Console.WriteLine("Please choose from one of the follow.\n\n" +
  "1) Search by author\n" +
  "2) Search by title keyword\n" +
  "3) Search by category\n" +
  "4) Search by number in list\n" +
  "5) Choose book at random\n" +
  "6) Return a book");
//Mike^

//List<Books> Selection = new List<Books>();
string selected = " ";
List<Books> Cart = new List<Books>();
int menuChoice = int.Parse(Console.ReadLine());
if (menuChoice == 1)
{
  List<Books> booksByAuthor = SwitchMethod.AuthorFinder(listBooks);
  foreach (Books book in booksByAuthor)
  {
    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{book.Title}", book.Author, book.Category, book.IsAvailable()));
         selected = Console.ReadLine();
        SwitchMethod.SelectedBooks(Cart,book);

        //  Selection = listBooks.Where(book => book.Equals(selected)).ToList();
        //Console.WriteLine(SwitchMethod.SelectedBooks(Selection));
    }
}
else if (menuChoice == 2)
{
  List<Books> booksByKeyword = SwitchMethod.KeyWordFinder(listBooks);
  foreach (Books book in booksByKeyword)
  {
    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{book.Title}", book.Author, book.Category, book.IsAvailable()));
        selected = Console.ReadLine();
         SwitchMethod.SelectedBooks(Cart,book);

    }
}
else if (menuChoice == 3)
{
  List<Books> booksByCategory = SwitchMethod.CategoryFinder(listBooks);
  foreach (Books book in booksByCategory)
  {
    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{book.Title}", book.Author, book.Category, book.IsAvailable()));
        selected = Console.ReadLine();
        SwitchMethod.SelectedBooks(Cart,book);


    }
}
else if (menuChoice == 4)
{
  int x = SwitchMethod.NumberFinder(listBooks);
 
    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", listBooks[x].Title, listBooks[x].Author, listBooks[x].Category, listBooks[x].IsAvailable()));
    selected = Console.ReadLine();
    SwitchMethod.SelectedBooks(Cart,listBooks[x]);


}
else if (menuChoice == 5) //Returns
{
  Console.WriteLine("Here is your random book selection. I personally love this one.\n");
  // Console.WriteLine(Books.RandomBook(listBooks));
  Books x = Books.RandomBook(listBooks);
  //selected = Console.ReadLine();
  SwitchMethod.SelectedBooks(Cart, x);
  Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", x.Title, x.Author, x.Category, x.IsAvailable()));
  //Mike^ swapped


  Console.WriteLine("\nWould you like to choose another?");
}
else if (menuChoice == 6)
{
  foreach (Books book in selectedBooks)
  {
    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{i}. {book.Title}", book.Author, book.Category, book.IsAvailable()));
    i++;
  }
  Console.WriteLine("Here are the books we currently have checked out, which book would you like to return");
  string returnChoice = Console.ReadLine();
  foreach (Books books in selectedBooks)
  {
    if (books.Title == (returnChoice))
    {
      listBooks.Add(books);
      SwitchMethod.ReturnBookM(selectedBooks);


      Console.WriteLine();
      filler = Validator.GetContinue($"Alright, I have returned that book for you. Would you like to return anymore books?");
    }
  }
  //Mike^
}


Console.WriteLine($"\nWould you like to check out a book from this list? \nPlease select \"Yes\" to pick from this list or select \"No\" to see more book options?");
string makeSelection = Console.ReadLine().ToLower().Trim();
if (makeSelection == "yes")
{
  Console.WriteLine("Which book would you like to check out?");
  string theirPick = Console.ReadLine().ToLower().Trim();
  foreach (Books books in listBooks)
  {
    if (books.Title == (theirPick))
    {
      selectedBooks.Add(books);
      SwitchMethod.CheckOutM(selectedBooks);
      DateTime checkOutDate = DateTime.Now;

      Console.WriteLine($"Alright, you're check out date is { Books.GetDueDate(checkOutDate).ToShortDateString()}");
      break;
    }
  }
}
else if (makeSelection == "no")
{
  filler = true;
  /*break;*/ //loop back through author 
}
//Mike^




Console.ReadLine();




//=================================================================================================================================


FileIO.fileWriter(listBooks);
//PersonFileIO.PersonFileReader()







