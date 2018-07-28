using System;

namespace MysteryBox.WebService.Exceptions
{
    public class ServiceClientException : Exception
    {
        public ServiceClientException(string message, Exception innerException)
        {
        }
    }
}
