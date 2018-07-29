using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MysteryBox.WebService.Models.Domainbox.Response
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot("Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
    public class DeleteContactResponse
    {
        public DeleteContactResponseEnvelopeBody Body { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class DeleteContactResponseEnvelopeBody
    {
        [XmlElement("DeleteContactResponse", Namespace = "https://sandbox.domainbox.net/")]
        public DeleteContactEnvelopeResponse Response { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    [XmlRoot(Namespace = "https://sandbox.domainbox.net/", IsNullable = false)]
    public class DeleteContactEnvelopeResponse
    {
        public DeleteContactResult DeleteContactResult { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sandbox.domainbox.net/")]
    public class DeleteContactResult
    {
        public int ResultCode { get; set; }

        public string ResultMsg { get; set; }

        public string TxID { get; set; }
    }
}
