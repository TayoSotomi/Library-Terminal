using Library;

FileIO.FileVerifier(); //Verifies that file is present.
List<Books> listBooks = FileIO.FileReader();//reads all files and places in book class.
//===================================================================================================================
//List of books

int i = 1;
foreach (Books book in listBooks)
{
    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}",$"{i}.{book.Title}",book.Author,book.Category,book.IsAvailable()));
    i++;
}

List<Books> test = SwitchMethod.AuthorFinder(listBooks);
foreach (Books book in test)
{
    Console.WriteLine(book.Title);
}

Console.WriteLine(SwitchMethod.NumberFinder(listBooks));






Console.ReadLine();

//=================================================================================================================================


FileIO.fileWriter(listBooks);


