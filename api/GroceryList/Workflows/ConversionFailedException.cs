using System;
using System.Runtime.Serialization;

namespace GroceryList.Workflows
{
    [Serializable]
    internal class ConversionFailedException : Exception
    {
        public ConversionFailedException()
        {
        }

        public ConversionFailedException(string message) : base(message)
        {
        }

        public ConversionFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConversionFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}