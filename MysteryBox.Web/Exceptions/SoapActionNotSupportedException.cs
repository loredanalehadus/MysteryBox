using System;

namespace MysteryBox.WebService.Exceptions
{
    public class SoapActionNotSupportedException : Exception
    {
        public SoapActionNotSupportedException(Type type)
            : base($"Soap action for type '{type}' is not supported.")
        {
        }
    }
}