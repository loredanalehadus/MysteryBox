using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MysteryBox.WebService.Models.Domainbox.Request
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    [XmlRoot("Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
    public class DeleteContactRequest
    {
        public DeleteContactRequestEnvelopeBody Body { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class DeleteContactRequestEnvelopeBody
    {
        [XmlElement(Namespace = "https://sandbox.domainbox.net/")]
        public DeleteContact DeleteContact { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    [XmlRoot(Namespace = "https://sandbox.domainbox.net/", IsNullable = false)]
    public class DeleteContact
    {
        public DeleteContactAuthenticationParameters AuthenticationParameters { get; set; }
        public DeleteContactCommandParameters CommandParameters { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class DeleteContactAuthenticationParameters
    {
        public string Reseller { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class DeleteContactCommandParameters
    {
        public int ContactId { get; set; }
    }
}
