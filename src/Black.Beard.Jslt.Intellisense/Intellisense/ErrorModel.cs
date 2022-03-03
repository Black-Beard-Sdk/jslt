namespace Bb.Intellisense
{

    public class ErrorModel : TokenModel
    {

        public ErrorModel()
        {

        }

        public string Code { get; set; }
        
        public string Message { get; set; }

        public override string ToString()
        {
            return Message.ToString();
        }

        public override int GetHashCode()
        {
            return Filename.GetHashCode() ^ Message.GetHashCode() ^ Text.GetHashCode() ^ (StartIndex).GetHashCode();
        }

    }

}
