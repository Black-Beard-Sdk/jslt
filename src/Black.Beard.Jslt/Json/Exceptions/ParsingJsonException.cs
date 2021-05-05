using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.JSon
{


    [Serializable]
    public class ParsingJsonException : Exception
    {
        public ParsingJsonException() { }
        public ParsingJsonException(string message) : base(message) { }
        public ParsingJsonException(string message, Exception inner) : base(message, inner) { }
        protected ParsingJsonException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
