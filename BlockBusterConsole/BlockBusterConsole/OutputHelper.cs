using BlockBuster.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBusterConsole
{
    class OutputHelper
    {
        public void WriteToConsole(List<Movie> movies)
        {
            Console.WriteLine("List of Movies");
            foreach(var m in movies)
            {
                Console.WriteLine($"MovieID: {m.MovieId}     Title:{m.Title}     Release Year: {m.ReleaseYear}");
            }
        }

        public void WriteToCSV(List<Movie> movies)
        {
            using (var writer = new StreamWriter("path\\to\\file.csv"))
                using(var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(movies);
            }
        }

        public void WriteMovies(List<Movie> movies, String input)
        {
            if (input.ToLower().Equals("csv"))
            {
                using (var writer = new StreamWriter(@"..\file.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(movies);
                    Console.WriteLine("Movies Written into folder *insert folder location here*");
                }
            }
            else if (input.ToLower().Equals("console"))
            {
                Console.WriteLine("List of Movies");
                foreach (var m in movies)
                {
                    Console.WriteLine($"MovieID: {m.MovieId}     Title:{m.Title}     Release Year: {m.ReleaseYear}");
                }
            }
            else
            {
                Console.WriteLine("Please pick an option between: CSV or Console");
                String userInput = Console.ReadLine();
                WriteMovies(movies, userInput);
            }
        }

    }
}
