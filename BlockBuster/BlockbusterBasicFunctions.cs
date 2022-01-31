using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster
{
    public class BlockbusterBasicFunctions
    {
        public static Movie GetMovieById(int id)
        {
            try
            {
                using(var context = new SE407_BlockBusterContext())
                {
                    return context.Movies.Find(id);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static List<Movie> GetAllMovies()
        {
            try
            {
                using(var context = new SE407_BlockBusterContext())
                {
                    return context.Movies.ToList();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        public static List<Movie> GetAllCheckedOutMovies()
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Join(db.Transactions,
                    m => m.MovieId,
                    t => t.Movie.MovieId,
                    (m, t) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,
                        CheckedIn = t.CheckedIn
                    }).Where(w => w.CheckedIn == "N")
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId
                    }).ToList();
            }
        }


        public static List<Movie> GetMoviesByGenreDescription(String Desc)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Join(db.Genres,
                    m => m.GenreId,
                    g => g.GenreId,
                    (m, g) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        GenreDescr = g.GenreDescr,
                        DirectorId = m.DirectorId
                    }).Where(g => g.GenreDescr == Desc)
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId
                    }).ToList();
            }
        }

        public static List<Movie> GetMoviesByDirectorLName(String LName)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Join(db.Directors,
                    m => m.DirectorId,
                    d => d.DirectorId,
                    (m, d) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        LastName = d.LastName,
                        DirectorId = m.DirectorId
                    }).Where(d => d.LastName == LName)
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId
                    }).ToList();
            }
        }


    }
}
