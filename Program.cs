using System;
using System.Collections.Generic;
using System.Linq;

namespace linqLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

            IEnumerable<string> LFruits = from fruit in fruits
                where fruit[0] == 'L'
                select fruit;

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 6 == 0 && number % 4 == 0);

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            IEnumerable<string> orderedNames = from name in names
                orderby name ascending
                select name;

            // // Build a collection of these numbers sorted in ascending order
            List<int> numberss = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> orderedNumbers = numberss.OrderBy(n => n);

            // Output how many numbers are in this list
            // Console.WriteLine(numberss.Count);

            // // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            // Console.WriteLine(purchases.Sum());

            // // What is our most expensive product?
            // Console.WriteLine(purchases.Max());

            //     Store each number in the following List until a perfect square is detected.
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            IEnumerable<int> untilSqrt = wheresSquaredo.TakeWhile(num => Convert.ToInt32(Math.Sqrt(num)) % 1 == 0);

            // // Build a collection of customers who are millionaires
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            List<Bank> banks = new List<Bank>() {
                new Bank(){ Symbol="FTB", Name = "First Tennessee Bank"},
                new Bank(){ Symbol="WF", Name="Wells Fargo"},
                new Bank(){ Symbol="BOA", Name="Bank of America"},
                new Bank(){ Symbol="CITI", Name="Citibank"}
            };
            //     Given the same customer set, display how many millionaires per bank.
            IEnumerable<Customer> millionaires = customers.Where(cust => cust.Balance > 1000000);

            var group = millionaires.GroupJoin(banks,
                m => m.Bank,
                s => s.Symbol,
                (m, s) => new Result (m.Name, s));

            // var groupTable =
            //     from m in millionaires
            //     join s in banks on m equals s.Symbol into g
            //     select new { Name = m, bankName = g };

            // foreach (var result in group)
            // {
            //     Console.WriteLine(result.name + ":");
            //     foreach (var p in result.result)
            //     {
            //         Console.WriteLine("   " + p.Name);
            //     }
            // }

            var millsByBalance = from millionaire in millionaires
                group millionaire by millionaire.Bank into mills
                orderby mills.Key
                select mills;

            // foreach (var mill in millsByBalance)
            // {
            //     var millCount = new List<string>();
            //     foreach (var cust in mill)
            //     {
            //         millCount.Add(cust.Name);
            //     }
            //     if (millCount.Count == 1)
            //     {
            //         Console.WriteLine($"There is {millCount.Count} millionaire at {mill.Key} bank.");

            //     } else {
            //         Console.WriteLine($"There are {millCount.Count} millionaires at {mill.Key} bank.");
            //     }
            // }
        }
    }

    public class Result
    {
        public string name;
        public IEnumerable<Bank> result;

        public Result(string name, IEnumerable<Bank> result)
        {
            this.name = name;
            this.result = result;
        }
    }
}
