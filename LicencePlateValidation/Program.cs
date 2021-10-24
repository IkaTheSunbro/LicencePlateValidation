using System;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;

namespace LicencePlateValidation
{
    class Program
    {
        static bool IsAllDigits(string s) => s.All(char.IsDigit);
        static bool IsAllLetters(string s) => s.All(char.IsLetter);

        static bool isNum(char num)
        {
            const string numbers = "1234567890";

            if (numbers.Contains(num))
            {
                return true;
            }

            return false;
        }

        static string PlateValidation(string[] args)
        {
            if (args[0].Length != 2)
            {
                return "Not Valid"; 
            }
            
            if (int.TryParse(args[0], out int Province))
            {
                if (Province >= 81 || Province < 1)
                {
                    return "Not Valid";
                }
            }

            if (args[1].Length + args[2].Length > 6)
            {
                return "Not Valid";
            }

            if (args[2].Length == 1)
            {
                return "Not Valid";
            }
            
            if (args[1].Length > 3)
            {
                return "Not Valid";
            }

            if (IsAllDigits(args[2]) && IsAllLetters(args[1]))
            {
                return "Valid";
            }

            return "Not Valid";
        }

        static void PlateExtractor()
        {
            string plateRaw = Console.ReadLine().ToUpper();
            plateRaw = Regex.Replace(plateRaw, @"\s+", "");
            string[] plate = new string[3];
            byte ColCount = 0; 

            for (int i = 1; i < plateRaw.Length; i++)
            {
                if (isNum(plateRaw[i - 1]) != isNum(plateRaw[i])) { ColCount++; }
            }

            if (ColCount != 2)
            {
                WriteLine("Not Valid");
                return;
            }

            ColCount = 0;

            for (int i = 1; i < plateRaw.Length; i++)
            {
                if (isNum(plateRaw[i - 1]) != isNum(plateRaw[i])) { plate[ColCount] += plateRaw[i - 1] ; ColCount++; }
                else { plate[ColCount] += plateRaw[i - 1];  }
            }

            plate[ColCount] += plateRaw[plateRaw.Length - 1];

            WriteLine(PlateValidation(plate));
        }

        static void Main(string[] args)
        {
            WriteLine("Enter Your Licence Plate: ");
            PlateExtractor();
        }
    }
}
