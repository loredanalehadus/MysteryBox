using System;

namespace MysteryBox.WebService.Exceptions
{
    public class ServiceClientException : Exception
    {
        public ServiceClientException(string baseAddress, Exception innerException)
            : base($"An error occured processing request to : {baseAddress}", innerException)
        {
        }
    }
}
