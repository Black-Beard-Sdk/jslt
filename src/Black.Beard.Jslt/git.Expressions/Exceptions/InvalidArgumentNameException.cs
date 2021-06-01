using System;

namespace Bb.Exceptions
{

    [Serializable]
    public class InvalidArgumentNameException : Exception
    {
        
        public InvalidArgumentNameException() { }
        
        public InvalidArgumentNameException(string message) : base(message) { }
        
        public InvalidArgumentNameException(string message, Exception inner) : base(message, inner) { }
        
        protected InvalidArgumentNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }

}
