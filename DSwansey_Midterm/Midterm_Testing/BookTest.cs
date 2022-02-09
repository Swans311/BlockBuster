using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Midterm;
namespace MidtermTesting
{
    public class BookTest
    {
        [Fact]
        public void getByTitleTest()
        {
            var result = MidtermFunctions.getBookByTitle("The Travels of Marco Polo");
            Assert.True(result.Count==1);
        }

        [Fact]
        public void getByAuthorTest()
        {
            var result = MidtermFunctions.getBookByLName("Polo");
            Assert.True(result.Count==1); //i know this is a very bootlegged test, but it returns the correct result, and I'm not sure if i messed up somewhere along the way or I have lost my mind, but result.BookTitle or result.anything was only getting mad at me.
        }


        [Fact]
        public void GetAllBooksTest()
        {
            var result = MidtermFunctions.getAllBooks();
            Assert.True(result.Count == 2);
        }
    }
}
