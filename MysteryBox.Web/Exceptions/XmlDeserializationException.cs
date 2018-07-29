using System;

namespace MysteryBox.WebService.Exceptions
{
    public class XmlDeserializationException : Exception
    {
        public XmlDeserializationException(string xmlPayload, Exception innerException)
            : base($"An error occured while deserializing xml payload: {xmlPayload}", innerException)
        {
        }
    }
}