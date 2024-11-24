using BooksSoapApi.Soap;
using Microsoft.AspNetCore.Mvc;

namespace BooksSoapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> Books = new()
        {
            new Book { Id = 1, Title = "Book One", Author = "Author A", Year = 2001 },
            new Book { Id = 2, Title = "Book Two", Author = "Author B", Year = 2005 }
        };

        [HttpPost]
        [Consumes("application/xml")]
        [Produces("application/xml")]
        public IActionResult Post([FromBody] SoapEnvelope envelope)
        {
            var response = new BookResponse();

            switch (envelope.Body.BookRequest.Operation)
            {
                case "GetBooks":
                    // Return all books; no Book field required
                    response.Books = Books;
                    response.Success = true;
                    break;

                case "AddBook":
                    if (envelope.Body.BookRequest.Book == null)
                    {
                        // Validation error for missing Book field
                        return BadRequest(new
                        {
                            Message = "Book details are required for the AddBook operation."
                        });
                    }

                    // Add the new book
                    Books.Add(envelope.Body.BookRequest.Book);
                    response.Success = true;
                    break;

                case "DeleteBook":
                    if (envelope.Body.BookRequest.Book?.Id == null)
                    {
                        // Validation error for missing Book ID
                        return BadRequest(new
                        {
                            Message = "Book ID is required for the DeleteBook operation."
                        });
                    }

                    // Find and delete the book
                    var book = Books.FirstOrDefault(b => b.Id == envelope.Body.BookRequest.Book.Id);
                    if (book != null)
                    {
                        Books.Remove(book);
                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                    }
                    break;

                default:
                    // Invalid operation
                    return BadRequest(new { Message = "Invalid operation specified." });
            }

            // Wrap the response in a SOAP envelope
            var soapResponse = new SoapEnvelope
            {
                Body = new SoapBody
                {
                    BookRequest = null // Clear request in response
                }
            };

            return Ok(soapResponse);
        }

    }
}