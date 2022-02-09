using System;
using Midterm.Models;

namespace MidtermConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //content goes here...
            Console.WriteLine("Hello Visitor, What can I do for you today?");
            Console.WriteLine("Option 1: Get Book by Title.");
            Console.WriteLine("Option 2: Get List of all Books we have.");
            Console.WriteLine("Option 3: Get Books by a specific Author.");
            Console.WriteLine("Please Enter 1,2,3 to select.");
            var _input = Console.ReadLine();
            var guestInput = Int32.Parse(_input);
            while(guestInput>3 || guestInput < 1)
            {
                Console.WriteLine("Please Enter 1,2, or 3");
                _input = Console.ReadLine();
                guestInput = Int32.Parse(_input);


            }
            if (guestInput == 1)
            {
                Console.WriteLine("Enter the book title you want to search for...");
                var input = Console.ReadLine();
                var b = Midterm.MidtermFunctions.getBookByTitle(input);
                Console.WriteLine("Do you want that as a CSV or printed to the console?");
                var filetype = Console.ReadLine();
                var mo = new MidtermOutput();
                mo.WriteBooks(b, filetype);
            }
            else if (guestInput == 2)
            {
                Console.WriteLine("Searching for all Books...");
                var input = Console.ReadLine();
                var b = Midterm.MidtermFunctions.getAllBooks();
                Console.WriteLine("Do you want that as a CSV or printed to the console?");
                var filetype = Console.ReadLine();
                var mo = new MidtermOutput();
                mo.WriteBooks(b, filetype);
            }
            else if (guestInput == 3)
            {
                Console.WriteLine("Enter the Author's Last Name you want to search for...");
                var input = Console.ReadLine();
                var b = Midterm.MidtermFunctions.getBookByLName(input);
                Console.WriteLine("Do you want that as a CSV or printed to the console?");
                var filetype = Console.ReadLine();
                var mo = new MidtermOutput();
                mo.WriteBooks(b, filetype);
            }
            else
            {

            }
            Console.WriteLine("Press Enter button to exit");
            Console.ReadLine();
        }
    }
}
