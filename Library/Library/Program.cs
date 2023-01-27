using Library;

FileIO.FileVerifier(); //Verifies that file is present.
List<Books> unlistBooks = FileIO.FileReader();//reads all files and places in book class.
List<Books> listBooks = unlistBooks.OrderBy(x => x.Title).ToList();
//===================================================================================================================
//List of books

int i = 1;
foreach (Books book in listBooks.OrderBy(x => x.Title))
{
    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}",$"{i}.{book.Title}",book.Author,book.Category,book.IsAvailable()));
    i++;
}







Console.ReadLine();

//=================================================================================================================================


FileIO.fileWriter(listBooks);


