using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace Bb.Jslt.Services.MultiCsv
{

    /// <summary>
    /// Class FileInformations
    /// </summary>
    public class FileInformations
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FileInformations"/> class.
        /// </summary>
        public FileInformations()
        {
            this.Metadatas = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the file information.
        /// </summary>
        /// <value>
        /// The file information.
        /// </value>
        public FileInfo FileInfo { get; set; }

        /// <summary>
        /// The _headers
        /// </summary>
        private OrderedDictionary _headers = new OrderedDictionary(20);


        /// <summary>
        /// Gets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        public OrderedDictionary Headers
        {
            get
            {
                return _headers;
            }
        }


        /// <summary>
        /// Get encoding detected by the Ude library
        /// </summary>
        public Encoding EncodingByUde { get; set; }


        public Dictionary<string, string> Metadatas { get; }

        /// <summary>
        /// Gets the header.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        internal HeaderReference GetHeader(string e, string schema)
        {
            HeaderReference h;

            if (!_headers.Contains(e)) _headers.Add(e, (h = new HeaderReference(e, schema)));
            else return _headers[e] as HeaderReference;

            return h;
        }

        private int _Index = 1;


    }

}
