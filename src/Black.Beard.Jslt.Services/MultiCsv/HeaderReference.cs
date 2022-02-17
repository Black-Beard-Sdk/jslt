using System.Collections.Generic;
using System.Diagnostics;

namespace Bb.Jslt.Services.MultiCsv
{


    /// <summary>
    /// Header Reference
    /// </summary>
    [DebuggerDisplay("{Schema}:{LabelLine}")]
    public class HeaderReference : List<ColumnDefinition>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderReference"/> class.
        /// </summary>
        /// <param name="headerName">The e.</param>
        internal HeaderReference(string headerName, string schema)
        {
            this.LabelLine = headerName.ToUpper();
            this.Schema = schema.ToUpper();
        }

        /// <summary>
        /// Gets the title of the line.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string LabelLine { get; }

        /// <summary>
        /// Gets the schema of the line.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Schema { get; }

        
    }

}
