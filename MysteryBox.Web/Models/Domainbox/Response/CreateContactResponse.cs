using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MysteryBox.WebService.Models.Domainbox.Response
{
    [Serializable, DesignerCategory("code"),
     XmlRoot("Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
    public class CreateContactResponse
    {
        public EnvelopeBody Body { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class EnvelopeBody
    {
        [XmlElement("CreateContactResponse", Namespace = "https://sandbox.domainbox.net/")]
        public Response Response { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    [XmlRoot(Namespace = "https://sandbox.domainbox.net/", IsNullable = false)]
    public class Response
    {
        [XmlElement("CreateContactResult")]
        public Result Result { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class Result
    {
        public byte ResultCode { get; set; }

        public string ResultMsg { get; set; }

        public string TxID { get; set; }

        public uint ContactId { get; set; }

        [XmlArrayItem(IsNullable = false)]
        public string[] TLDs { get; set; }
    }
}
