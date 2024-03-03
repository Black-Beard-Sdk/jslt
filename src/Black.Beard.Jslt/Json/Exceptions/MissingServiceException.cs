namespace Bb.Exceptions
{

    [System.Serializable]
    public class MissingServiceException : System.Exception
    {
        public MissingServiceException() { }
        public MissingServiceException(string message) : base(message) { }
        public MissingServiceException(string message, System.Exception inner) : base(message, inner) { }
        protected MissingServiceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


}
