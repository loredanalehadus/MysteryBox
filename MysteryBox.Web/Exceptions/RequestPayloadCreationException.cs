using System;

namespace MysteryBox.WebService.Exceptions
{
    public class RequestPayloadCreationException : Exception
    {
        public RequestPayloadCreationException(Exception innerException)
            : base("A xml serialization error occured.", innerException)
        {
        }
    }
}