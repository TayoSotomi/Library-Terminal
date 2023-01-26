using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class FileIO
    {
        //methods

        public static void FileVerifier(string filePath)
        {

            if (!File.Exists(filePath))
            {
                StreamWriter tempWriter = new StreamWriter(filePath);
                tempWriter.WriteLine("Burnt|Burnt|Burnt|false|1/26/2023 2:20:05 PM");
                tempWriter.Close();
            }
        }
        public static List<Books> FileReader(string filePath)
        {
            List<Books> listBooks = new List<Books>();
            StreamReader libraryCatalogueReader = new StreamReader(filePath);

            while (true)
            {
                string line = libraryCatalogueReader.ReadLine();
                if (line == null)
                {
                    break;
                }
                else
                {
                    string[] parts = line.Split("|");
                    Books book = new Books(parts[0], parts[1], parts[2], bool.Parse(parts[3]), DateTime.Parse(parts[4]));
                    listBooks.Add(book);
                }
            }
            libraryCatalogueReader.Close();
            
            return listBooks;
        }
        public static void fileWriter(List<Books> books, string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);
            foreach(Books b in books)
            {
                writer.WriteLine($"{b.Title}|{b.Author}|{b.Category}|{b.Status}|{b.Due}");
            }
            writer.Close();
        }
    }
}
