#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using Bb.Json.Utilities;
using System.IO;
using System.Globalization;
using ZstdSharp.Unsafe;

namespace Bb.Json.Linq
{
    /// <summary>
    /// Represents a JSON array.
    /// </summary>
    /// <example>
    ///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParseArray" title="Parsing a JSON Array from Text" />
    /// </example>
    public partial class JEnumerable : JToken, IEnumerable<JToken>
    {

        /// <summary>
        /// Gets the node type for this <see cref="JToken"/>.
        /// </summary>
        /// <value>The type.</value>
        public override JTokenType Type => JTokenType.Array;

        public override bool HasValues => throw new NotImplementedException();

        /// <summary>
        /// Initializes a new instance of the <see cref="JEnumerable"/> class from another <see cref="JEnumerable"/> object.
        /// </summary>
        /// <param name="other">A <see cref="JEnumerable"/> object to copy from.</param>
        public JEnumerable(IEnumerator<JToken> items)
        {
            this._enumarator = items;
        }

        public override IEnumerator<JToken> GetEnumerator()
        {
            return this._enumarator;
        }

        internal override bool DeepEquals(JToken node)
        {
            return false;
            //return (node is JEnumerable t && ContentsEqual(t));
        }

        internal override JToken CloneToken()
        {
            throw new NotImplementedException();
        }

        internal override int GetDeepHashCode()
        {
            throw new NotImplementedException();
        }

        public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
        {
            throw new NotImplementedException();
        }

        private readonly IEnumerator<JToken> _enumarator;

    }

}