using System.Collections.Generic;
using System.Diagnostics;

namespace Bb.Json.Jslt.CustomServices.MultiCsv
{


    /// <summary>
    /// Class block
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Block : Dictionary<string, string>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        public Block()
        {

            this._subs = new List<Block>();

        }

        
        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="line">The line.</param>
        /// <param name="rawContent">Content of the raw.</param>
        internal Block(HeaderReference header, int line, string rawContent)
            : base(header.Count)
        {
            this.Name = header.LabelLine;
            this.Line = line;
            this.RawContent = rawContent;
            this._subs = new List<Block>();
        }

        /// <summary>
        /// Clear the dictionary and the value of the Block
        /// </summary>
        public new void Clear()
        {
            base.Clear();
            Name = null;
            RawContent = null;
            ErrorOnblock = false;
            ErrorMsg = null;
        }


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the line.
        /// </summary>
        /// <value>
        /// The line.
        /// </value>
        public int Line { get; set; }


        /// <summary>
        /// Gets or sets the content of the raw.
        /// </summary>
        /// <value>
        /// The content of the raw.
        /// </value>
        public string RawContent { get; set; }

        /// <summary>
        /// Gets or sets the error status of the row
        /// </summary>
        /// <value> true if there is an error, false either</value> 
        public bool ErrorOnblock { get; set; }

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string ErrorMsg { get; set; }

        public IEnumerable<Block> Subs { get => _subs; }

        public void Add(Block block)
        {
            if (!_subs.Contains(block))
                _subs.Add(block);
            else
            {

            }
        }


        public T Accept<T>(IVisitor<T> visitor)
        {

            return visitor.Visit(this);

        }


        private List<Block> _subs;


    }
     
}
