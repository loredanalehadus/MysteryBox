﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MysteryBox.WebService.Models.Domainbox.Request
{
    [XmlRoot("Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
    public class ModifyContactRequest
    {
        public ModifyContactRequestEnvelopeBody Body { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class ModifyContactRequestEnvelopeBody
    {
        [XmlElement(Namespace = "https://sandbox.domainbox.net/")]
        public ModifyContact ModifyContact { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    [XmlRoot(Namespace = "https://sandbox.domainbox.net/", IsNullable = false)]
    public class ModifyContact
    {
        public ModifyContactAuthenticationParameters AuthenticationParameters { get; set; }

        public ModifyContactCommandParameters CommandParameters { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class ModifyContactAuthenticationParameters
    {
        public string Reseller { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class ModifyContactCommandParameters
    {
        public int ContactId { get; set; }

        public ModifyContactCommandParametersContact Contact { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class ModifyContactCommandParametersContact
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

        public string Email { get; set; }

        public string Fax { get; set; }
    }
}