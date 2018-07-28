using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MysteryBox.WebService.Models.Domainbox.Request
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlRoot("Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
    public class CreateContactRequest
    {
        public EnvelopeBody Body { get; set; }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public partial class EnvelopeBody
    {
        [XmlElement(Namespace = "https://sandbox.domainbox.net/")]
        public CreateContact CreateContact { get; set; }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    [XmlRoot(Namespace = "https://sandbox.domainbox.net/", IsNullable = false)]
    public partial class CreateContact
    {
        public CreateContactAuthenticationParameters AuthenticationParameters { get; set; }

        public CreateContactCommandParameters CommandParameters { get; set; }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public partial class CreateContactAuthenticationParameters
    {
        public string Reseller { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
    
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public partial class CreateContactCommandParameters
    {
        public string TLD { get; set; }

        public string LaunchPhase { get; set; }

        public CreateContactCommandParametersContact Contact { get; set; }
    }
    
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public partial class CreateContactCommandParametersContact
    {
        public string Name { get; set; }

        public string Organisation { get; set; }

        public string Street1 { get; set; }

        public object Street2 { get; set; }

        public object Street3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Postcode { get; set; }

        public string CountryCode { get; set; }

        public decimal Telephone { get; set; }

        public object TelephoneExtension { get; set; }

        public string Email { get; set; }

        public object Fax { get; set; }
    }
}
