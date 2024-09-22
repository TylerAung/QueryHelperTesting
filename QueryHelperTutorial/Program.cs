// See https://aka.ms/new-console-template for more information
using QueryHelperTutorial.Models;
using System.Linq.Expressions;
using static QueryHelperTutorial.Program;
using static System.Reflection.Metadata.BlobBuilder;

namespace QueryHelperTutorial;

class Program
{
    static void Main(string[] args)
    {
        var libraryCollections = new List<LibraryCollection>();

        for (int i = 1; i <= 20; i++)
        {
            var collection = new LibraryCollection
            {
                Id = i,
                Genre = GetRandomGenre(),
                Created = DateTime.Now.AddMonths(-i),
                Updated = DateTime.Now,
                books = GenerateMockBooks(i)
            };
            libraryCollections.Add(collection);
        }

        var queryableBooks = libraryCollections.AsQueryable();

        Expression<Func<LibraryCollection, bool>> filterByAuthor = b => b.books.Any(c => c.author.Name == "C") ;

        Expression<Func<LibraryCollection, bool>> filterByGenre = b => b.Genre == "Fantasy";


        var filteredBooks = QueryHelper.FilterByCondition(queryableBooks, filterByAuthor);
    }

    // Define your static method within the class
    private static List<Book> GenerateMockBooks(int collectionId)
    {
        var books = new List<Book>();
        var random = new Random();
        int numberOfBooks = random.Next(1, 6); // Each collection will have between 1 and 5 books

        for (int i = 1; i <= numberOfBooks; i++)
        {
            books.Add(new Book
            {
                BookId = collectionId * 100 + i, // Unique book Id per collection
                BookTitle = $"Book Title {i}",
                BookDescription = $"Description of book {i}",
                Created = DateTime.Now.AddMonths(-i),
                Updated = DateTime.Now,
                author = new Author
                {
                    Id = i,
                    Name = $"Author Name {i}",
                    Description = $"Description of author {i}",
                    AuthorId = Guid.NewGuid()
                }
            });
        }

        return books;
    }

    private static string GetRandomGenre()
    {
        var genres = new List<string>
    {
        "Fiction", "Non-Fiction", "Science Fiction", "Fantasy", "Biography", "History", "Children's", "Mystery", "Romance", "Self-Help"
    };

        var random = new Random();
        return genres[random.Next(genres.Count)];
    }

    public static class QueryHelper
    {
        public static IQueryable<LibraryCollection> FilterByCondition(IQueryable<LibraryCollection> query, Expression<Func<LibraryCollection, bool>> condition)
        {
            return query.Where(condition);
        }
    }
}

