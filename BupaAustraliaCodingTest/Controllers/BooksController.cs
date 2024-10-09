using BupaAustraliaCodingTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace BupaAustraliaCodingTest.Controllers
{
    public class BooksController : Controller
    {
        private static readonly List<Owner> Owners = new List<Owner>
        {
            new Owner
            {
                Name = "Jane",
                Age = 23,
                Books = new List<Book>
                {
                    new Book { Name = "Hamlet", Type = "Hardcover" },
                    new Book { Name = "Wuthering Heights", Type = "Paperback" }
                }
            },
            new Owner
            {
                Name = "Charlotte",
                Age = 14,
                Books = new List<Book>
                {
                    new Book { Name = "Hamlet", Type = "Paperback" }
                }
            },
            new Owner
            {
                Name = "Max",
                Age = 25,
                Books = new List<Book>
                {
                    new Book { Name = "React: The Ultimate Guide", Type = "Hardcover" },
                    new Book { Name = "Gulliver's Travels", Type = "Hardcover" },
                    new Book { Name = "Jane Eyre", Type = "Paperback" },
                    new Book { Name = "Great Expectations", Type = "Hardcover" }
                }
            },
            new Owner
            {
                Name = "William",
                Age = 15,
                Books = new List<Book>
                {
                    new Book { Name = "Great Expectations", Type = "Hardcover" }
                }
            },
            new Owner
            {
                Name = "Charles",
                Age = 17,
                Books = new List<Book>
                {
                    new Book { Name = "Little Red Riding Hood", Type = "Hardcover" },
                    new Book { Name = "The Hobbit", Type = "Ebook" }
                }
            }
        };


        [HttpGet("categorizedBooks")]
        public IActionResult GetCategorizedBooks()
        {
            // Categorize books based on owner's age
            var adultBooks = Owners.Where(o => o.Age >= 18)
                                   .SelectMany(o => o.Books)
                                   .Select(b => b.Name)
                                   .Distinct()
                                   .OrderBy(b => b)
                                   .ToList();

            var childrenBooks = Owners.Where(o => o.Age < 18)
                                      .SelectMany(o => o.Books)
                                      .Select(b => b.Name)
                                      .Distinct()
                                      .OrderBy(b => b)
                                      .ToList();

            // Create the structured response
            var categorizedBooks = new
            {
                Adults = adultBooks,
                Children = childrenBooks
            };

            return Ok(categorizedBooks);
        }
    }
}
