using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MysteryBox.WebService.Models.Domainbox.Request
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    [XmlRoot("Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
    public class QueryContactRequest
    {
        public QueryContactRequestEnvelopeBody Body { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class QueryContactRequestEnvelopeBody
    {
        [XmlElement(Namespace = "https://sandbox.domainbox.net/")]
        public QueryContact QueryContact { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    [XmlRoot(Namespace = "https://sandbox.domainbox.net/", IsNullable = false)]
    public class QueryContact
    {
        public QueryContactAuthenticationParameters AuthenticationParameters { get; set; }
        public QueryContactCommandParameters CommandParameters { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class QueryContactAuthenticationParameters
    {
        public string Reseller { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class QueryContactCommandParameters
    {
        public int ContactId { get; set; }
    }
}