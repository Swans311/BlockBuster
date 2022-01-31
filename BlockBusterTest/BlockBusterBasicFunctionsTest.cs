using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BlockBuster;

namespace BlockBusterTest
{
    public class BlockBusterBasicFunctionsTest
    {
        [Fact]
        public void GetMovieByIdTest()
        {
            var result = BlockbusterBasicFunctions.GetMovieById(11);
            Assert.True(result.Title.ToLower() == "vertigo");
            Assert.True(result.ReleaseYear == 1958);

        }

        [Fact]
        public void GetAllMoviesTest()
        {
            var result = BlockbusterBasicFunctions.GetAllMovies();
            Assert.True(result.Count == 49);
        }

        [Fact]
        public void GetAllCheckedOutMovies()
        {
            var result = BlockbusterBasicFunctions.GetAllCheckedOutMovies();
            Assert.True(result.Count == 3);
        }

        [Fact]
        public void GetMoviesByGenreTest()
        {
            var result = BlockbusterBasicFunctions.GetMoviesByGenreDescription("Drama");
            Assert.True(result.Count == 27);
        }

        [Fact]
        public void GetMoviesByDirectorLNameTest()
        {
            var result = BlockbusterBasicFunctions.GetMoviesByDirectorLName("Eastwood");
            Assert.True(result.Count == 1);
        }

    }
}
