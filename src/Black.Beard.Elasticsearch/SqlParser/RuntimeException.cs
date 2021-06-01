﻿using System;

namespace Bb.Elastic.Parser
{

    [Serializable]
    public class RuntimeException : Exception
    {
        public RuntimeException() { }
        public RuntimeException(string message) : base(message) { }
        public RuntimeException(string message, Exception inner) : base(message, inner) { }
        protected RuntimeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
