namespace Bb.Expresssions
{

    /// <summary>
    /// internal unique index generator
    /// </summary>
    internal class PrivatedIndex
    {

        /// <summary>
        /// return unique index.this method is thread safe.
        /// </summary>
        /// <returns>unique index</returns>
        public static int GetNewIndex()
        {
            lock (_lock)
            {

                if (_indexVariables == int.MaxValue)
                    _indexVariables = 0;

                return ++_indexVariables;

            }

        }

        private static object _lock = new object();
        private static volatile int _indexVariables = 0;

    }

}
