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

            if (!File.Exists("../../../User.txt"))
            {
                StreamWriter tempWriter = new StreamWriter("../../../User.txt");
                tempWriter.WriteLine("Burnt|Burnt|Burnt");
                tempWriter.Close();
            }
        }
        public static List<User> PersonFileReader()
        {
            List<User> listUser = new List<User>();
            StreamReader UserReader = new StreamReader("../../../User.txt");

            while (true)
            {
                string line = UserReader.ReadLine();
                if (line == null)
                {
                    break;
                }
                else
                {
                    string[] parts = line.Split("|");
                    if(parts.Length <3 ) 
                    {
                        break;
                    }
                    User user = new User(parts[0], parts[1], parts[2]);
                    listUser.Add(user);
                }
            }
            UserReader.Close();

            return listUser;
        }
        public static void fileWriter(List<User> User, List<Books> CheckedOutBooks)
        {
            StreamWriter writer = new StreamWriter("../../../User.txt");
            foreach (User u in User)
            {
                writer.WriteLine($"{u.UserName}|{u.Password}|");
                foreach(Books book in CheckedOutBooks)
                {
                    writer.Write($"{book.Title}%");
                }
            }
            writer.Close();
        }
    }
}

