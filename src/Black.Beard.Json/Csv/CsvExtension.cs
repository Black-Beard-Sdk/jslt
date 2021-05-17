using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Sdk.Csv
{

    /// <summary>
    /// Csv extension
    /// </summary>
    public static class CsvExtension
    {

        /// <summary>
        /// Readers the CSV.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <param name="hasHeaders">if set to <c>true</c> [has headers].</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="quote">The quote.</param>
        /// <returns></returns>
        public static IEnumerable<System.Data.IDataReader> ReaderCsv(this FileInfo self, bool hasHeaders, char delimiter, char quote)
        {
            if (self.Exists)
            {
                using (var _txt = self.OpenText())
                {
                    using (CsvReader csv = new CsvReader(_txt, hasHeaders, delimiter, quote, '\\', '#', ValueTrimmingOptions.All, (int)self.Length))
                    {
                    
                        System.Data.IDataReader reader = csv;

                        while (reader.Read())
                            yield return reader;

                    }
                }
            }
        
        }

    }

}
