using System.Xml.Serialization;

namespace BooksSoapApi.Soap
{
    [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SoapEnvelope
    {
        [XmlElement("Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public SoapHeader Header { get; set; } = new SoapHeader();

        [XmlElement("Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public SoapBody Body { get; set; } = new SoapBody();
    }

    public class SoapHeader
    {
    }

    public class SoapBody
    {
        [XmlElement("BookRequest", Namespace = "http://example.com/books")]
        public BookRequest BookRequest { get; set; }
    }
}