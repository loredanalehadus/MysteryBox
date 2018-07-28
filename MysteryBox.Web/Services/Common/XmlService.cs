using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MysteryBox.WebService.Exceptions;

namespace MysteryBox.WebService.Services.Common
{
    public class XmlService : IXmlService
    {
        public string Serialize<T>(T payload) where T : class
        {
            var payloadType = typeof(T);
            var xmlSerializer = new XmlSerializer(payloadType);
            var xmlSerializerNamespaces = new XmlSerializerNamespaces();

            xmlSerializerNamespaces.Add("s", "http://www.w3.org/2003/05/soap-envelope");
            xmlSerializerNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xmlSerializerNamespaces.Add("xsd", "http://www.w3.org/2001/XMLSchema");

            var xmlSettings = new XmlWriterSettings { OmitXmlDeclaration = true };

            try
            {
                using (var stringWriter = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(stringWriter, xmlSettings))
                    {
                        xmlSerializer.Serialize(writer, payload, xmlSerializerNamespaces);
                    }

                    return stringWriter.ToString();
                }
            }
            catch (Exception exception)
            {
                throw new RequestPayloadCreationException(exception);
            }
        }

        public T DeserializeXml<T>(string content) where T : class
        {
            using (var stringReader = new StringReader(content))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return xmlSerializer.Deserialize(stringReader) as T;
            }
        }
    }
}