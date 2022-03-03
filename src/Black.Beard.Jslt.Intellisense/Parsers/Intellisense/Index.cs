namespace Bb.Parsers.Intellisense
{
    public class Index<T>
    {
        public Index(int startIndex, int stopIndex, T item)
        {
            this.StartIndex = startIndex;
            this.StopIndex = stopIndex;
            this.Item = item;
        }

        public int StartIndex { get; }

        public int StopIndex { get; }

        public T? Item { get; }

        public int Distance(int position)
        {
            return this.StartIndex - position;
        }

        public override string ToString()
        {
            return $"{StartIndex} : {StopIndex}";
        }
    }

}
