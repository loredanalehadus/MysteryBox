using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MysteryBox.WebService.Models.Domainbox.Response
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    [XmlRoot("Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
    public class QueryContactResponse
    {
        public QueryContactResponseEnvelopeBody Body { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class QueryContactResponseEnvelopeBody
    {

        [XmlElement("QueryContactResponse", Namespace = "https://sandbox.domainbox.net/")]
        public QueryContactEnvelopeResponse Response { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    [XmlRoot(Namespace = "https://sandbox.domainbox.net/", IsNullable = false)]
    public class QueryContactEnvelopeResponse
    {
        [XmlElement("QueryContactResult")]
        public QueryContactResult Result { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class QueryContactResult
    {
        public byte ResultCode { get; set; }

        public string ResultMsg { get; set; }

        public string TxID { get; set; }

        [XmlElement("Contact")]
        public QueryResultContact Contact { get; set; }

        public bool Linked { get; set; }

        [XmlArrayItem(IsNullable = false)]
        public string[] TLDs { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class QueryResultContact
    {
        public string Name { get; set; }

        public string Organisation { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string Street3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Postcode { get; set; }

        public string CountryCode { get; set; }

        public string Telephone { get; set; }

        public string TelephoneExtension { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public int ContactId { get; set; }

        public string CustomerId { get; set; }
    }
}