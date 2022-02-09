using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midterm.Models;

namespace Midterm
{
    public class MidtermFunctions
    {
        public static List<Book> getBookByTitle(String title)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books
                    .Where(b => b.BookTitle == title)
                    .Select(b => new Book
                    {
                        BookId = b.BookId,
                        BookTitle = b.BookTitle,
                        GenreId = b.GenreId,
                        AuthorId = b.AuthorId,
                        YearOfRelease = b.YearOfRelease
                    }).ToList();
            }
        }

        public static List<Book> getAllBooks()
        {
            using (var context = new SE407_BookStoreContext())
            {
                return context.Books.ToList();
            }
        }



        public static List<Book> getBookByLName(String Lname)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books
                    .Join(db.Authors,
                    b => b.AuthorId,
                    a => a.AuthorId,
                    (b, a) => new
                    {
                        BookId = b.BookId,
                        BookTitle = b.BookTitle,
                        GenreId = b.GenreId,
                        AuthorId = b.AuthorId,
                        AuthorLast = a.AuthorLast,
                        AuthorFirst = a.AuthorFirst,
                        YearOfRelease = b.YearOfRelease
                    }).Where(a => a.AuthorLast == Lname)
                    .Select(b => new Book
                    {
                        BookId = b.BookId,
                        BookTitle = b.BookTitle,
                        GenreId = b.GenreId,
                        AuthorId = b.AuthorId,
                        YearOfRelease = b.YearOfRelease
                    }).ToList();
            }
        }

    }
}
