using System.Collections.Generic;
using System.Xml.Serialization;

namespace BooksSoapApi.Soap
{
    [XmlRoot("BookResponse", Namespace = "http://example.com/books")]
    public class BookResponse
    {
        [XmlElement("Success")]
        public bool Success { get; set; }

        [XmlArray("Books")]
        [XmlArrayItem("Book")]
        public List<Book> Books { get; set; }
    }
}