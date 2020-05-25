using System;
using System.Runtime.Serialization;

namespace CoreImplementation.Database
{
    [Serializable]
    internal class CollectionNotRegisteredException : Exception
    {
        public CollectionNotRegisteredException()
        {
        }

        public CollectionNotRegisteredException(string message) : base(message)
        {
        }

        public CollectionNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CollectionNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}