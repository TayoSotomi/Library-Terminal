﻿using Library;

string filepath = "../../../Books.txt";

FileIO.FileVerifier(filepath); //Verifies that file is present.
List<Books> listBooks = FileIO.FileReader(filepath);//reads all files and places in book class.
//===================================================================================================================
//List of books

int i = 1;
foreach (Books book in listBooks)
{
    Console.WriteLine(String.Format("{0,-50}{1,20}{2,15}{3,15}",$"{i}.{book.Title}",book.Author,book.Category,book.GetStatus(book.Status)));
    i++;
}










Console.ReadLine();

//=================================================================================================================================


FileIO.fileWriter(listBooks, filepath);


