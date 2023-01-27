using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PersonFileIO
    {
        //methods


        public static void PersonFileVerifier()
        {

            if (!File.Exists("../../../Person.txt"))
            {
                StreamWriter tempWriter = new StreamWriter("../../../Person.txt");
                tempWriter.WriteLine("Burnt|Burnt|Burnt|false|1/26/2023 2:20:05 PM");
                tempWriter.Close();
            }
        }
        public static List<Books> PersonFileReader()
        {
            List<Books> listBooks = new List<Books>();
            StreamReader libraryCatalogueReader = new StreamReader("../../../Person.txt");

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
                    if (parts.Length < 4)
                    {
                        break;
                    }
                    Books book = new Books(parts[0], parts[1], parts[2], bool.Parse(parts[3]), DateTime.Parse(parts[4]));
                    listBooks.Add(book);
                }
            }
            libraryCatalogueReader.Close();

            return listBooks;
        }
        public static void fileWriter(List<Books> books)
        {
            StreamWriter writer = new StreamWriter("../../../Person.txt");
            foreach (Books b in books)
            {
                writer.WriteLine($"{b.Title}|{b.Author}|{b.Category}|{b.Status}|{b.Due}");
            }
            writer.Close();
        }
    }
}

