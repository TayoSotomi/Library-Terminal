using Library;

string filepath = "../../../Books.txt";

FileIO.FileVerifier(filepath); //Verifies that file is present.
List<Books> listBooks = FileIO.FileReader(filepath);//reads all files and places in book class.

foreach (Books book in listBooks)
{
    Console.WriteLine(book.GetInfo());
}

FileIO.fileWriter(listBooks, filepath);

