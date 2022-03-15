using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CodingChallenge.DataAccess.Interfaces;
using CodingChallenge.DataAccess.Models;
using CodingChallenge.Utilities;

namespace CodingChallenge.DataAccess
{
    public class LibraryService : ILibraryService
    {
        public LibraryService() { }

        private IEnumerable<Movie> GetMovies()
        {
            return _movies ?? (_movies = ConfigurationManager.AppSettings["LibraryPath"].FromFileInExecutingDirectory().DeserializeFromXml<Library>().Movies);
        }
        private IEnumerable<Movie> _movies { get; set; }

        public int SearchMoviesCount(string title)
        {
            return SearchMovies(title).Count();
        }

        public IEnumerable<Movie> SearchMovies(string title, int? skip = null, int? take = null, string sortColumn = null, SortDirection sortDirection = SortDirection.Ascending)
        {
            var movies = GetMovies().Where(s => s.Title.Contains(title));
            movies= movies.GroupBy(s => s.Title).Select(s => s.FirstOrDefault());
            if (sortColumn !=null && sortDirection == SortDirection.Ascending)
            {
                if(sortColumn=="ID")
                {
                    movies = movies.OrderBy(s => s.ID);
                }
                else if(sortColumn == "Title")
                {
                    movies = movies.Select(s => new Movie { ID = s.ID, Title = s.Title.Replace("A ",""), Year = s.Year, Rating = s.Rating });
                    movies = movies.Select(s => new Movie { ID = s.ID, Title = s.Title.Replace("An ",""), Year = s.Year, Rating = s.Rating });
                    movies = movies.Select(s => new Movie { ID = s.ID, Title = s.Title.Replace("The ",""), Year = s.Year, Rating = s.Rating });
                    movies = movies.OrderBy(s => s.Title);
                }
                else if (sortColumn == "Year")
                {
                    movies = movies.OrderBy(s => s.Year);
                }
                else if (sortColumn == "Rating")
                {
                    movies = movies.OrderBy(s => s.Rating);
                }
            }
            if (sortColumn != null && sortDirection == SortDirection.Descending)
            {
                if (sortColumn == "ID")
                {
                    movies = movies.OrderByDescending(s => s.ID);
                }
                else if (sortColumn == "Title")
                {
                    movies = movies.Select(s => new Movie { ID = s.ID, Title = s.Title.Replace("A ", ""), Year = s.Year, Rating = s.Rating });
                    movies = movies.Select(s => new Movie { ID = s.ID, Title = s.Title.Replace("An ", ""), Year = s.Year, Rating = s.Rating });
                    movies = movies.Select(s => new Movie { ID = s.ID, Title = s.Title.Replace("The ", ""), Year = s.Year, Rating = s.Rating });
                    movies = movies.OrderByDescending(s => s.Title);
                }
                else if (sortColumn == "Year")
                {
                    movies = movies.OrderByDescending(s => s.Year);
                }
                else if (sortColumn == "Rating")
                {
                    movies = movies.OrderByDescending(s => s.Rating);
                }
            }
            if (skip.HasValue && take.HasValue)
            {
                movies = movies.Skip(skip.Value).Take(take.Value);
            }
            return movies.ToList();
        }
    }
}
