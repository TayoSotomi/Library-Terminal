using Circle;
using Library;
using System.Security.Cryptography.X509Certificates;

FileIO.FileVerifier(); //Verifies that file is present.
PersonFileIO.PersonFileVerifier();//verifies file present
List<Books> unlistBooks = FileIO.FileReader(); //unsorted books
List<Books> listBooks = unlistBooks.OrderBy(x => x.Title).ToList();//alphabetical order
List<Books> selectedBooks = FileIO.FileReader(); //This holds the books they've selected.
List<User> userList = PersonFileIO.PersonFileReader(); //List of users


bool filler = true;
bool runProgram = true;

List<Books> Cart = new List<Books>();

List<Books> Available = listBooks.Where(B => B.Status == true).ToList();
Console.WriteLine($"\n\nWelcome to the Campus Library of the Mouseion Institute of History, my name is {Books.PickName()} and I will be your \nlibrarian today. Currently, " +
  $"we have {Available.Count} books available to check out.");

Console.WriteLine("Are you a new or returning user?");
string newUserName = "";
string newPassword = "";
int userIndex = 0;
while (true)
{
    string answer = Console.ReadLine().Trim().ToLower();

    if (answer == "new")
    {
        newUserName = User.newUserName();
        newPassword = User.newPassword();
        userList.Add(new User(newUserName, newPassword, "No Checked out books"));
        userIndex = userList.FindIndex(x => x.UserName == newUserName);
        break;
    }
    else if (answer.Contains("return"))
    {
        newUserName = User.returningUser(userList);
        if(newUserName == "No Username found.") 
        {
            Console.WriteLine("Username incorrect too many times. Have a good day.");
            runProgram=false;
            break;
        }
        else if (newUserName == "Julius Ceaser")
        {
            Console.WriteLine("Thanks for putting humans back centuries.");
            runProgram=false;
            listBooks.Clear();
            break;
        }
        else
        {
            userIndex = userList.FindIndex(x => x.UserName == newUserName);
        }
        runProgram = User.returningPassword(userIndex, userList);

        break;
    }
    else
    {
        Console.WriteLine("Please enter new or returning.");
    }
}


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
        Console.Clear();
    SwitchMethod.ReturnBookM(User.ReturnUserBooks(listBooks,userList,userIndex),userList,userIndex);
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
    string userBooks = "";
    SwitchMethod.CheckOutM(ref checkedOut);
    foreach (Books book in checkedOut)
    {
      Console.WriteLine(book.GetInfoCheckOut());
            userBooks += book.Title.Trim() + "%";
    }
    userList[userIndex].CheckedOutBooks = userBooks;
    Console.WriteLine("Have a good day.");
    runProgram = false;
            
  }
  Console.WriteLine("Press Enter to continue.");
  Console.ReadLine();
  Console.Clear();


}
//=================================================================================================================================

FileIO.fileWriter(listBooks);
PersonFileIO.fileWriter(userList);
//PersonFileIO.PersonFileReader()








