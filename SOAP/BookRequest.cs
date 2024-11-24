using System.Xml.Serialization;

namespace BooksSoapApi.Soap
{
    public class BookRequest
    {
        [XmlElement("Operation")]
        public string Operation { get; set; } // e.g., "GetBooks", "AddBook"

        [XmlElement("Book", IsNullable = true)] // Mark the field as nullable for optional use
        public Book? Book { get; set; } // Allow null values for Book
    }

    public class Book
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Author")]
        public string Author { get; set; }

        [XmlElement("Year")]
        public int Year { get; set; }
    }
}