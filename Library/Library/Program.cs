using Library;

FileIO.FileVerifier(); //Verifies that file is present.
List<Books> listBooks = FileIO.FileReader();//reads all files and places in book class.
//===================================================================================================================
//List of books

int i = 1;
foreach (Books book in listBooks)
{
  Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}", $"{i}.{book.Title}", book.Author, book.Category, book.IsAvailable()));
  i++;
}


Console.WriteLine($"\n\nWelcome to the Campus Library of the Mouseion Institute of History, my name is {PickName()}, and I wll be your \nlibrarian today. Now how can I help you.");
Console.WriteLine("Please choose from one of the follow.\n\n" +
  "1) Search by author\n" +
  "2) By Title Keyword\n" +
  "3) Category\n" +
  "4) Return book\n" +
  "5) Choose book at Random");

int menuChoice = int.Parse(Console.ReadLine());
//switch (menuChoice)
//{
if (menuChoice == 1)
{
  Console.WriteLine($"Which Author would you like to search by?");
}
else if (menuChoice == 2)
{
  Console.WriteLine($"Enter a word to return titles of books containing that word.");
}
else if (menuChoice == 3)
{
  Console.WriteLine($"Please enter a category from the choices listed below to display books from that category.");
  int counter = 0; 
  foreach (Books book in listBooks)
  {
    counter++;
    Console.WriteLine($"{counter}. {book.Category}");
  }
}
else if (menuChoice == 4)
{
  Console.WriteLine($"Which Author would you like to search by?");
}
//case 1:
//  //menuChoice == 1;
//    Console.WriteLine(Books($"{listBooks.Author}") );
//    string Authorchoice = Console.ReadLine();
//  if (listBooks.Contains(Authorchoice))
//  {

//  }
//    break;



Console.ReadLine();



//Method not working as public class method keeping as static now will fix later
static string PickName()
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
//=================================================================================================================================


FileIO.fileWriter(listBooks);


