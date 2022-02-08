using System;
using BlockBuster.Models;

namespace BlockBusterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter CSV or Console for how you would like the movies returned to you.");
            string userInput = Console.ReadLine();
            var b = BlockBuster.BlockbusterBasicFunctions.GetAllMovies();
            var oh = new OutputHelper();
            //oh.WriteToCSV(b);
            oh.WriteMovies(b, userInput);
            Console.WriteLine("Enter to exit");
            Console.ReadLine();
        }
    }
}
