using System;

namespace Bb.Exceptions
{
    [Serializable]
    public class DuplicatedArgumentNameException : Exception
    {
        public DuplicatedArgumentNameException() { }
        public DuplicatedArgumentNameException(string message) : base(message) { }
        public DuplicatedArgumentNameException(string message, Exception inner) : base(message, inner) { }
        protected DuplicatedArgumentNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
