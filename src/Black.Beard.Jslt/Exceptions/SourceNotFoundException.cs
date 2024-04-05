using System;

namespace Bb.Exceptions
{
    [Serializable]
    public class SourceNotFoundException : Exception
    {
        
        public SourceNotFoundException() { }
        
        public SourceNotFoundException(string message) : base(message) { }
        
        public SourceNotFoundException(string message, Exception inner) : base(message, inner) { }
        
        protected SourceNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }

}
