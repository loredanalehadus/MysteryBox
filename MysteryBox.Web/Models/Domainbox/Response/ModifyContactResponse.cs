using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MysteryBox.WebService.Models.Domainbox.Response
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot("Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
    public class ModifyContactResponse
    {
        [XmlElement("EnvelopeBody")] public ModifyContactResponseEnvelopeBody Body { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class ModifyContactResponseEnvelopeBody
    {
        [XmlElement("ModifyContactResponse", Namespace = "https://sandbox.domainbox.net/")]
        public ModifyContactEnvelopeResponse Response { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    [XmlRoot(Namespace = "https://sandbox.domainbox.net/", IsNullable = false)]
    public class ModifyContactEnvelopeResponse
    {
        public ModifyContactResult ModifyContactResult { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class ModifyContactResult
    {
        public int ResultCode { get; set; }

        public string ResultMsg { get; set; }

        public string TxID { get; set; }
    }
}