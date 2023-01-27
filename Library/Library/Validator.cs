using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    
    public class Validator
    {
        public static int intValidator(List<Books> x)
        {
            Console.WriteLine("Please enter the number of the book you would like to view.");
            int result = 0;
            while (!int.TryParse(Console.ReadLine(), out result) || result < 1 || result > x.Count)
            {
                Console.WriteLine($"Only positive numbers between 1 and {x.Count}");
            }
            return result - 1;
        }
        public static int GetUserNumberInt()
        {
            int result = 0;
            Console.WriteLine("Please enter a number.");

            while (int.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Invalid Input. Try again");
            }

            return result;
        }


        public static int GetNumberInRangeInt(int min)
        {
            int result = int.MinValue;
            while (result <= min)
            {
                result = GetUserNumberInt();
                if (result <= min)
                {
                    Console.WriteLine($"Number must be greater or equal to {min}");
                }
            }

            return result;
        }


        public static double GetUserNumberDouble()
        {
            double result = 0;
            Console.WriteLine("Please enter a number.");

            while (double.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Invalid Input. Try again");
            }

            return result;
        }


        public static double GetNumberInRangeDouble(double min)
        {
            double result = double.MinValue;
            while(result <= min)
            {
                result = GetUserNumberDouble();
                if(result <= min)
                {
                    Console.WriteLine($"Number must be greater or equal to {min}");
                }
            }

            return result;
        }

        public static decimal GetUserNumberDecimal()
        {
            decimal result = 0;
            Console.WriteLine("Please enter a number.");

            while (decimal.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Invalid Input. Try again");
            }

            return result;
        }


        public static decimal GetNumberInRangeDecimal(decimal min)
        {
            decimal result = decimal.MinValue;
            while (result <= min)
            {
                result = GetUserNumberDecimal();
                if (result <= min)
                {
                    Console.WriteLine($"Number must be greater or equal to {min}");
                }
            }

            return result;
        }

        public static float GetUserNumberFloat()
        {
            float result = 0;
            Console.WriteLine("Please enter a number.");

            while (float.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Invalid Input. Try again");
            }

            return result;
        }


        public static float GetNumberInRangeFloat(float min)
        {
            float result = float.MinValue;
            while (result <= min)
            {
                result = GetUserNumberFloat();
                if (result <= min)
                {
                    Console.WriteLine($"Number must be greater or equal to {min}");
                }
            }

            return result;
        }

        public static bool GetContinue()
        {
            bool result = true;

            while (true)
            {
                Console.WriteLine("Would you like to run again? y/n");
                string choice = Console.ReadLine().Trim().ToLower();
                if(choice == "y")
                {
                    result = true;
                    break;
                }
                else if(choice == "n")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            return result;
        }

        //overloaded
        public static bool GetContinue(string msg)
        {
            bool result = true;

            while (true)
            {
                Console.WriteLine($"{msg} y/n");
                string choice = Console.ReadLine().Trim().ToLower();
                if (choice == "y")
                {
                    result = true;
                    break;
                }
                else if (choice == "n")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            return result;
        }

        //overloaded
        public static bool GetContinue(string msg, string yes, string no)
        {
            bool result = true;

            while (true)
            {
                Console.WriteLine($"{msg} {yes}/{no}");
                string choice = Console.ReadLine().Trim().ToLower();
                if (choice == yes.ToLower().Trim())
                {
                    result = true;
                    break;
                }
                else if (choice == no.ToLower().Trim())
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            return result;
        }

    }
}
