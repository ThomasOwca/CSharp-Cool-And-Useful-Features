using System.Linq;
using System;
using System.Collections.Generic;

namespace C__Features
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueSearch = true;
            string continueSearchResponse;

            Console.WriteLine(Concatenate("Hi", "Thomas,", "you are awesome!")); // displays the expected msg
            Console.WriteLine($"Trying with null value | result: {Add(null, 16)}"); // displays 16
            Console.WriteLine($"Trying with non-null value | result: {Add(20, 16)}"); // displays 20
            Console.WriteLine($"Trying with null value | result Ver2: {AddVer2(null, 16)}"); // displays 16
            Console.WriteLine($"Trying with non-null value | result Ver2: {AddVer2(20, 16)}\n"); // displays 36
            Console.WriteLine($"Result from FindRandomNumber method: {FindNumberInList(20000000)}");

            List<string> cars = new List<string>() 
            { 
                "Mitsubishi Eclipse", "Chevy Camaro", "Ford Mustang", "Toyota Supra", "Chevy Aveo", "Ford Edge",
                "Dodge Charger", "Dodge Viper", "Dodge Avenger", "Toyota Camry", "Toyota Corolla", "Mazda 3", "Mazda 6"
            };

            while (continueSearch) 
            {
                Console.Write("Search cars with keyword: ");
                string keyword = Console.ReadLine();

                // This is a case-insensitive search.
                var results = cars.Where(car => car.ToLower().Contains(keyword.ToLower()));

                if (results != null)
                {
                    Console.WriteLine("Here are the keyword matched results.\n");

                    foreach (var result in results)
                    {
                        Console.WriteLine(result);
                    }
                }
                else
                    Console.WriteLine($"No result produced from the keyword, {keyword}.");

                do 
                {
                    Console.Write("\nMake another search (y/n)?: ");
                    continueSearchResponse = Console.ReadLine();

                    if (continueSearchResponse.ToLower() == "n") 
                    {
                        continueSearch = false;
                        break;
                    }
                    else if (continueSearchResponse.ToLower() == "y")
                    {
                        
                    }
                    else
                    {
                        Console.WriteLine("Invalid response.");
                    }

                } while (continueSearchResponse.ToLower() != "n" && continueSearchResponse.ToLower() != "y");
            }

            Console.Write("Thanks for using the search service!");
        }

        static string Concatenate(string x, string y, string z)
        {
            return $"{x} {y} {z}";
        }

        static int Add(int? x, int y)
        {
            return x ?? Convert.ToInt32(x) + y;
        }

        static int AddVer2(int? x, int y)
        {
            return x != null ? (int)x + y : y;
        }

        static int FindNumberInList(int x)
        {
            int? searchResult;
            List<int> numbers = new List<int>();
            Random random = new Random(0);

            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(random.Next(1, 1000));
            }

            searchResult = numbers.FirstOrDefault(number => number == x);

            if (searchResult.HasValue)
                return (int)searchResult;
            else
                return -99;
        }
    }
}
