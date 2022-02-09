using Midterm.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermConsole
{
    class MidtermOutput
    {
        public void WriteToConsole(List<Book> books)
        {
            Console.WriteLine("List of Books");
            foreach(var b in books)
            {
                Console.WriteLine($"BookID: {b.BookId}    Title: {b.BookTitle}");
            }
        }

        public void WriteToCSV(List<Book> books)
        {
            using (var writer = new StreamWriter("path\\to\\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(books);
            }
        }

        public void WriteBooks(List<Book> books, string input) //this is for the get by title option
        {
            if (input.ToLower().Equals("csv"))
            {
                WriteToCSV(books);
                Console.WriteLine("Movies Written into folder *insert folder location here*");

            }
            else if (input.ToLower().Equals("console"))
            {
                //Console.WriteLine("List of Books");
                WriteToConsole(books);
            }
            else
            {
                Console.WriteLine("Please pick an option between: CSV or Console");
                String userInput = Console.ReadLine();
                WriteBooks(books, userInput);
            }
        }

    }
}
