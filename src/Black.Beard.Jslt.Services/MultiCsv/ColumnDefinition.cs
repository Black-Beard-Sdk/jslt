namespace Bb.Jslt.Services.MultiCsv
{

    /// <summary>
    /// Class ColumnDefinition
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class ColumnDefinition
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnDefinition"/> class.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="colunmName">Name of the colunm.</param>
        /// <param name="index">The index.</param>
        internal ColumnDefinition(HeaderReference header, string colunmName, int index)
        {
            this._parent = header;
            this.Name = colunmName;
            this.Index = index;
        }

        private HeaderReference _parent;


        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        public int Index { get; }
    }

}
