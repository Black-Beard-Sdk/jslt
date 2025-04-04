using System.Threading;

namespace Bb.Intellisense
{

    public class BoxParser
    {

        public string SourceFile { get; internal set; }



        public void Lock()
        {
            while (Interlocked.CompareExchange(ref locked, 1, 0) != 0)
            {
                Task.Yield();
            }

        }

        public void Unlock()
        {
            locked = 0;
        }

        private int locked;

    }

}
