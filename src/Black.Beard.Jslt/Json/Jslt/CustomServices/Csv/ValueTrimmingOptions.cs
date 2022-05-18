using System;

namespace Bb.Json.Jslt.CustomServices.Csv
{
    /// <summary>
    /// Value trimming options
    /// </summary>
    [Flags]
	public enum ValueTrimmingOptions
	{

        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The unquoted only
        /// </summary>
        UnquotedOnly = 1,

        /// <summary>
        /// The quoted only
        /// </summary>
        QuotedOnly = 2,

        /// <summary>
        /// All
        /// </summary>
        All = UnquotedOnly | QuotedOnly
	}
}